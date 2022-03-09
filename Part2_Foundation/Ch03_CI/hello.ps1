function Invoke-DotNetTest
{
    [CmdletBinding()]
    param(
        [Parameter()]
        [string]
        $Path = (Get-Location),

        [Parameter()]
        [string]
        $Tool = "coverlet.msbuild",

        [Parameter()]
        [switch]
        $Recurse,

        [Parameter()]
        [switch]
        $CodeCoverage,

        [Parameter()]
        [switch]
        $GenerateReport,

        [Parameter()]
        [string]
        $CoverletOutputFormat = 'cobertura'
    )

    Write-Host $CodeCoverage

    #$args = @()

    # Test dependencies, fail early
    Get-Command -Name 'dotnet.exe' -CommandType Application -ErrorAction Stop | Out-Null

    if($GenerateReport -and -not $CodeCoverage) {
        throw "-GenerateReport parameter is only valid when -CodeCoverage parameter is also present."
    }

    $reportTool = Get-Command "reportgenerator" -ErrorAction SilentlyContinue
    if($GenerateReport.IsPresent -and -not $reportTool) {
        dotnet tool install --global dotnet-reportgenerator-globaltool
    }
    elseif($GenerateReport.IsPresent) {
        dotnet tool update --global dotnet-reportgenerator-globaltool
    }

    $mergeWith = @()
    function Get-MergeWith {
        $mergeWith | ForEach-Object {
            "/p:MergeWith=""$($_)"""
        }
    }

    function Get-Args {
        param(
            [switch]
            $Last
        )

        $args = @()

        if ($PSCmdlet.MyInvocation.BoundParameters["Verbose"].IsPresent) {
            $args += "--verbosity normal"
        }
        if($CodeCoverage.IsPresent) {
            $args += "/p:CollectCoverage=true"

            if($Last.IsPresent){
                $args += "/p:CoverletOutputFormat=$CoverletOutputFormat" 
            }

            $args += Get-MergeWith
        }

        return $args
    }

    if((Get-Item -Path $Path -ErrorAction Stop) -is [System.IO.FileInfo]) {
        $Path = $info.Directory.FullName
    }

    $projects1 = Get-ChildItem -Path $Path -Filter '*.csproj' -Recurse:$Recurse 

    $projects = Get-ChildItem -Path $Path -Filter '*.csproj' -Recurse:$Recurse |
        Where-Object {
            $xml = [xml](Get-Content -Path $_.FullName)
            $null -ne ($xml.Project.ItemGroup.PackageReference | Where-Object Include -eq 'Microsoft.NET.Test.Sdk') -and
            $null -ne ($xml.Project.ItemGroup.PackageReference | Where-Object Include -eq $Tool)
        }

    if (-not $projects) {
        throw "Could not find any dotnet project files in provided path: $Path"
    }

    $projects | Select-Object -SkipLast 1 | ForEach-Object {
        Get-ChildItem -Path $_.Directory -Filter "coverage.json" -File | Remove-Item
        #$args = Get-Args
        #Write-Host $args
        # Write-Output (Get-Args)

        # Write-Verbose "Running: dotnet test $args $($_.FullName)"
        # & dotnet test (Get-Args) ""$($_.FullName)""
        Write-Verbose "Running: dotnet test $args $($_.FullName)"
        & dotnet test $args ""$($_.FullName)""
        $mergeWith += "$($_.Directory)/coverage.json"
    }

    $projects | Select-Object -Last 1 | ForEach-Object {
        Get-ChildItem -Path $Path -Filter TestCoverage -Directory | Remove-Item -Recurse:$Recurse

        #$args = (Get-Args -Last)
        #Write-Host $args
        #Write-Output Get-Args

        # Write-Verbose "Running: dotnet test $args $($_.FullName)"
        # & dotnet test (Get-Args -Last) ""$($_.FullName)""
        Write-Verbose "Running: dotnet test $args $($_.FullName)"
        & dotnet test $args ""$($_.FullName)""

        if($GenerateReport.IsPresent){
            & reportgenerator -reports:$(Join-Path `
                -Path $_.Directory `
                -ChildPath "coverage.$CoverletOutputFormat.xml") `
                -targetdir:$Path/TestCoverage `
                -reportTypes:htmlInline
        }
    }

    if ($GenerateReport -and
        -not ([Environment]::GetCommandLineArgs() -contains '-NonInteractive')) {
        & "$Path/TestCoverage/index.htm"
    }
}

Invoke-DotNetTest -Path "C:\Temp\dotnet-ci" -Recurse -CodeCoverage

# -Recurse -CodeCoverage 옵션 제외