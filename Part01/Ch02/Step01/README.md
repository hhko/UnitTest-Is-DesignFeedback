# 코드 커버리지

| 형식       | 파일 이름              |
|-----------|------------------------|
| json      | coverage.json          |
| lcov      | coverage.info          |
| cobertura | coverage.cobertura.xml |
| opencover | coverage.opencover.xml |


    <!-- "coverage-gutters.coverageFileNames": [
        "lcov.info",
        "cov.xml",
        "coverage.xml",
        "jacoco.xml",
        "coverage.info"
    ], -->

- **개별** 단위 테스트 결과 파일을 생성한다.
- **통합** 코드 커버리지 파일을 생성한다.

## 단위 테스트 실행 : 개별 코드 커버리지
```
+---------------+------+--------+--------+
| Module        | Line | Branch | Method |
+---------------+------+--------+--------+
| ClassLibrary1 | 100% | 100%   | 100%   |
+---------------+------+--------+--------+

+---------+------+--------+--------+
|         | Line | Branch | Method |
+---------+------+--------+--------+
| Total   | 100% | 100%   | 100%   |
+---------+------+--------+--------+
| Average | 100% | 100%   | 100%   |
+---------+------+--------+--------+


+---------------+------+--------+--------+
| Module        | Line | Branch | Method |
+---------------+------+--------+--------+
| ClassLibrary3 | 0%   | 100%   | 0%     |
+---------------+------+--------+--------+

+---------+------+--------+--------+
|         | Line | Branch | Method |
+---------+------+--------+--------+
| Total   | 0%   | 100%   | 0%     |
+---------+------+--------+--------+
| Average | 0%   | 100%   | 0%     |
+---------+------+--------+--------+


+---------------+------+--------+--------+
| Module        | Line | Branch | Method |
+---------------+------+--------+--------+
| ClassLibrary2 | 0%   | 100%   | 0%     |
+---------------+------+--------+--------+

+---------+------+--------+--------+
|         | Line | Branch | Method |
+---------+------+--------+--------+
| Total   | 0%   | 100%   | 0%     |
+---------+------+--------+--------+
| Average | 0%   | 100%   | 0%     |
+---------+------+--------+--------+
```
```shell
# 필수 패키지 추가
# dotnet add {단위 테스트 프로젝트} package coverlet.msbuild

# 단위 테스트 실행
#   - CoverletOutputFormat 옵션
#     > %2c => ','
#     > json,lcov,cobertura,opencover
#     > json%2clcov%2ccobertura%2copencover
dotnet test `
	/p:CollectCoverage=true  `
	/p:CoverletOutput=./TestResults/Coverage/ `
	/p:CoverletOutputFormat=json%2clcov%2ccobertura%2copencover

# --logger : 복수개 logger을 지정할 수 있다.
# --results-directory : logger 출력 파일 경로를 지정할 수 있다.
# /p:Exclude 제외? 네임스페이?
dotnet test `
	--logger "console;verbosity=detailed" `
	--logger "trx;LogFileName=TestResults.trx" `
	--results-directory ./TestResults/Logs `
	/p:CollectCoverage=true  `
	/p:CoverletOutput=./TestResults/Coverage/ `
	/p:CoverletOutputFormat=lcov%2copencover%2cjson%2ccobertura `
        /p:Exclude="[xunit.*]*
```

## 단위 테스트 실행 : 통합 코드 커버리지
```
+---------------+------+--------+--------+
| Module        | Line | Branch | Method |
+---------------+------+--------+--------+
| ClassLibrary3 | 0%   | 100%   | 0%     |
+---------------+------+--------+--------+
| ClassLibrary2 | 0%   | 100%   | 0%     |
+---------------+------+--------+--------+
| ClassLibrary1 | 100% | 100%   | 100%   |
+---------------+------+--------+--------+

+---------+--------+--------+--------+
|         | Line   | Branch | Method |
+---------+--------+--------+--------+
| Total   | 33.33% | 100%   | 33.33% |
+---------+--------+--------+--------+
| Average | 33.33% | 100%   | 33.33% |
+---------+--------+--------+--------+
```
```shell
# 방법 1.
#
# /maxcpucount:1 직렬 실행
# /p:MergeWith= ... .json 파일로 통합(반드시 josn 파일이어야 한다)
dotnet test `
	/p:CollectCoverage=true  `
	/p:CoverletOutput=./../../TestResults/Coverage/ `
	/p:MergeWith=./../../TestResults/Coverage/coverage.json `
	/p:CoverletOutputFormat=lcov%2copencover%2cjson `
	/maxcpucount:1

# 방법 2.
#
# ...
```

## 코드 커버리지 생성
```shell
# HTML(OpenCover) 코드 커버리지 생성
reportgenerator `
	-reports:**/TestResults/Coverage/coverage.opencover.xml `
	-targetdir:./TestResults/CoverageHtml `
	-reporttypes:Html `
	-historydir:./TestResults/CoverageHistory

# XML(Cobertura) 코드 커버리지 생성
reportgenerator `
	-reports:**/TestResults/Coverage/coverage.cobertura.xml `
	-targetdir:./TestResults/CoverageCobertura `
	-reporttypes:Cobertura
```

| 구분                 | 개별 | 통합   | 옵션 |
|----------------------|------|-------|------|
| dotnet test          | 완료 | TODO? | 네임스페이스 제외?, 코드 제외? |
| reportgenerator      | -    | 완료  |   |
| VSCode CodeCoverage  | 완료 | -     | 파일명 완료  |
| VSCode Test Explorer | 완료 | 완료   |   |
| VSCode tasks.json    | -     | 완료 | 단축키 완료   |

- 결과 폴더 지우기(clear) : `TestResults`
  - `dotnet test`
  - `reportgenerator`

### VSCode Settings

#### `tasks.json`
```json
{
    "version": "2.0.0",
    "tasks": [
        {
            "label": "test",
            "command": "dotnet",
            "type": "process",
            "args": [
                "test",
                "/p:CollectCoverage=true",
	            "/p:CoverletOutput=./TestResults/Coverage/",
	            "/p:CoverletOutputFormat=json%2clcov%2ccobertura%2copencover"
            ],
            "problemMatcher": "$msCompile"
        }
```

#### `keybindings.json`
```json
// Place your key bindings in this file to override the defaultsauto[]
[
    {
        "key": "ctrl+shift+t",
        "command": "workbench.action.tasks.runTask",
        "args": "test"
    }
]
```

#### `settings.json`
```json
"dotnet-test-explorer.testArguments": "/p:CollectCoverage=true /p:CoverletOutput=./TestResults/Coverage/ /p:CoverletOutputFormat=json%2clcov%2ccobertura%2copencover",
"dotnet-test-explorer.testProjectPath": "**\\*.UnitTest.csproj",
"dotnet-test-explorer.treeMode": "merged",

"coverage-gutters.showGutterCoverage": true,
"coverage-gutters.showLineCoverage": true,
"coverage-gutters.showRulerCoverage": true,
"coverage-gutters.coverageFileNames": [
	"lcov.info",
	"cov.xml",
	"coverage.xml",
	"jacoco.xml",
	"coverage.info"
],
```