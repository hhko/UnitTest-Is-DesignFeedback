using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
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

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath TestsDirectory => RootDirectory / "tests";
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            TestsDirectory.GlobDirectories("**/bin", "**/obj", "**/TestResult").ForEach(DeleteDirectory);
            EnsureCleanDirectory(ArtifactsDirectory);
        });

    Target Restore => _ => _
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
        });

    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetTest(s => s
                .SetProjectFile(Solution)

                // --configuration Release
                // --configuration Debug
                .SetConfiguration(Configuration)

                // --no-build
                .EnableNoBuild()

                // --logger console;verbosity=detailed
                // --logger junit;LogFilePath=./TestResult/Junit/{assembly}.xml;MethodFormat=Class;FailureBodyFormat=Verbose
                .SetLoggers(
                    "console;verbosity=detailed",
                    "junit;LogFilePath=\"./TestResult/Junit/{assembly}.xml\";MethodFormat=Class;FailureBodyFormat=Verbose")
                    //"junit;LogFilePath=\"" + JunitDirectory + "/{assembly}.xml\";MethodFormat=Class;FailureBodyFormat=Verbose")

                .SetProcessArgumentConfigurator(args => args
                    .Add("-p:CollectCoverage=true")
                    .Add("-p:CoverletOutput=\"{0}/\"", "./TestResult/CodeCoverage")                 // 경로 문자열 끝에 반드시 "/"으로 끝나야 폴더로 인식한다. 예. Folder/
                    .Add("-p:CoverletOutputFormat={0}", "json%2clcov%2ccobertura%2copencover")));   // %2c: ',' -> json, lcov, cobertura, opencover


                // .SetProcessArgumentConfigurator(args => args
                //     .Add("/property:CollectCoverage=true")
                //     .Add("/property:CoverletOutput=\"{0}/\"", CoverageDirectory)      // 경로 문자열 끝에 반드시 "/"으로 끝나야 폴더로 인식한다
                //     .Add("/property:CoverletOutputFormat={0}", format)
                //     .Add("/property:MergeWith=\"{0}\"", CoverageDirectory / "coverage.json")));
        });
}
