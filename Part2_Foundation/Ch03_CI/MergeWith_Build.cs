using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using Nuke.Common.Tools.Coverlet;
using Nuke.Common.Tools.ReportGenerator;
using Nuke.Common.Tools.GitVersion;

[CheckBuildProjectConfigurations(TimeoutInMilliseconds = 2000)]
[ShutdownDotNetAfterServerBuild]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main () => Execute<Build>(x => x.Test);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution] readonly Solution Solution;

    // [PackageExecutable(
    // packageId: "plantumlclassdiagramgenerator",
    // packageExecutable: "puml-gen.exe")]
    // readonly Tool Puml;
    [LocalExecutable(@"%USERPROFILE%\.dotnet\tools\puml-gen.exe")]
    readonly Tool Puml;
//[LocalExecutable("./tools/corflags.exe")]

    //[GitVersion] readonly GitVersion GitVersion;
    //[GitRepository] readonly GitRepository GitRepository;

    AbsolutePath ArtifactsDirectory => RootDirectory / ".artifacts";

    AbsolutePath CoverageDirectory => ArtifactsDirectory / "coverage";

    AbsolutePath JunitDirectory => ArtifactsDirectory / "junit";

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            EnsureCleanDirectory(ArtifactsDirectory);
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoRestore());
                //.SetFileVersion(GitVersion.GetNormalizedFileVersion())
                //.SetAssemblyVersion(GitVersion.AssemblySemVer));
        });

    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            var projects = GlobFiles(RootDirectory, "**/*.*Test*.csproj");

            // 마지막 제외한 프로젝트 n-1개 코드 커버리지
            projects
                .SkipLast(1)
                .ForEach(project =>
                    ExecuteTest(project, CoverletOutputFormat.json));

            // 마지막 프로젝트 1개 코드 커버리지
            ExecuteTest(projects.Last(), CoverletOutputFormat.lcov);
        });

    Target Report => _ => _
        .DependsOn(Test)
        .Executes(() =>
        {
            // reportgenerator `
            // 	-reports:**/artifacts/coverage/coverage.info `                # lcov 통합 코드 커버리지 결과 파일
            // 	-targetdir:./artifacts/coverage/report `
            // 	-reporttypes:Html `
            // 	-historydir:./artifacts/coverage/report-history
            ReportGeneratorTasks.ReportGenerator(_ => _
                // C:\Users\{계정}\.nuget\packages\reportgenerator\5.0.4\tools
                //      \net5.0
                //      \net6.0
                //      \net47
                //      \netcoreapp3.1
                .SetFramework("net6.0")
                .SetReports("**/artifacts/coverage/coverage.info")          // lcov 통합 코드 커버리지 결과 파일
                .SetTargetDirectory(CoverageDirectory / "report")
                .SetHistoryDirectory(CoverageDirectory / "report-history")
                .SetReportTypes(ReportTypes.Html));
        });

    // dotnet test `
    //   --no-build `
    //   --configuration Release
    //   --logger "console;verbosity=detailed" `
    //   --logger "junit;LogFilePath=../artifacts/gitlab/{assembly}.xml;MethodFormat=Class;FailureBodyFormat=Verbose" `
    //   /p:CollectCoverage=true `
    //   /p:CoverletOutput=../artifacts/coverage/ `
    //   /p:CoverletOutputFormat=json                       # 마지막을 제외한 테스트 프로젝트
    //   /p:CoverletOutputFormat=lcov                       # 마지막 테스트 프로젝트
    //   /p:MergeWith=../artifacts/coverage/coverage.json"
    void ExecuteTest(string project, CoverletOutputFormat format)
    {
        DotNetTest(_ => _
            .SetProjectFile(project)

            // --configuration Release
            // --configuration Debug
            .SetConfiguration(Configuration)

            // --no-build
            .EnableNoBuild()

            // --logger
            .SetLoggers(
                "console;verbosity=detailed",
                "junit;LogFilePath=\"" + JunitDirectory + "/{assembly}.xml\";MethodFormat=Class;FailureBodyFormat=Verbose")

            .SetProcessArgumentConfigurator(args => args
                .Add("/property:CollectCoverage=true")
                .Add("/property:CoverletOutput=\"{0}/\"", CoverageDirectory)      // 경로 문자열 끝에 반드시 "/"으로 끝나야 폴더로 인식한다
                .Add("/property:CoverletOutputFormat={0}", format)
                .Add("/property:MergeWith=\"{0}\"", CoverageDirectory / "coverage.json")));

        // TODO
        // - architecture
        // - --results-directory
        //   SetResultsDirectory(ArtifactsDirectory / "tests")
        // - SetExcludeByFile
        // - SetUseSourceLink
        // - SetLogOutput
        // - SetFramework("netcoreapp2.0")
        //
        // NOT TODO
        // .SetCoverletOutput(ArtifactsDirectory / "coverage//")

        //Puml.

        //Puml.Pac.packageExecutablePaths
    }
}