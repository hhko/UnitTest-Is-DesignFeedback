```shell
# 1. 패키지 추가
dotnet add .\Helloworld.UnitTest\ package FluentAssertions
dotnet add .\Helloworld.UnitTest\ package coverlet.msbuild
dotnet add .\Helloworld.UnitTest\ package JunitXml.TestLogger

# 2. 테스트 대상 프로젝트 참조
dotnet add .\Helloworld.UnitTest\ reference .\Helloworld\

# 3. 테스트
# https://docs.gitlab.com/ee/ci/unit_test_reports.html#net-example
# dotnet test 결과물 구성
# TestResults
#  - Coverage
#      - coverage.cobertura.xml
#      - coverage.opencover.xml
#      - coverage.info
#      - coverage.json
#  - GitLab
#      - Helloworld.UnitTest.xml
dotnet test `
	/p:CollectCoverage=true  `
	/p:CoverletOutput=./TestResults/Coverage/ `
	/p:CoverletOutputFormat=json%2clcov%2ccobertura%2copencover `
	--logger:"junit;LogFilePath=./TestResults/Gitlab/{assembly}.xml;MethodFormat=Class;FailureBodyFormat=Verbose"

# 4. .gitignore 폴더 추가
TestResults/

# 5. .gitlab-ci.yml 작성
tests:
  stage: test
  script:
    - dotnet test .\Src\CodeCoverageByCI\CodeCoverageByCI.sln
        /p:CollectCoverage=true
        /p:CoverletOutput=./TestResults/Coverage/
        /p:CoverletOutputFormat=json%2clcov%2ccobertura%2copencover
        --logger:"junit;LogFilePath=./TestResults/Gitlab/{assembly}.xml;MethodFormat=Class;FailureBodyFormat=Verbose"
  artifacts:
    when: always
    reports:
      junit:
       - ./**/TestResults/Gitlab/*.xml

# 6. 코드 커버리지 파싱
# 메뉴 > Settings > CI/CD > General pipelines > Test coverage parsing
# https://docs.gitlab.com/ee/ci/pipelines/settings.html#test-coverage-examples
Total\s*\|\s*(\d+(?:\.\d+)?)

# 7. CI/CD 상태 Markdown 연동
# 메뉴 > Settings > CI/CD > General pipelines
#   > Pipeline status
#   > Coverage report
#
# README.md 파일에 추가한다.
```