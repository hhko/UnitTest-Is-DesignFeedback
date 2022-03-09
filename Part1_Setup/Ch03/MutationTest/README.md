```shell
dotnet test `
    /p:CollectCoverage=true  `
	/p:CoverletOutput=./TestResults/Coverage/ `
	/p:CoverletOutputFormat=json%2clcov%2ccobertura%2copencover

# 단위 테스트 프로젝트
# /.config/dotnet-tools.json
dotnet new tool-manifest
dotnet tool install dotnet-stryker
dotnet tool uninstall dotnet-stryker
dotnet tool restore

dotnet stryker -o
```