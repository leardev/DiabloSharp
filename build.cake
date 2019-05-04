#addin nuget:?package=Cake.MiniCover&version=0.28.1

///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var buildType = Argument("buildtype", "dev");
var repositoryRoot = new DirectoryPath("./").MakeAbsolute(Context.Environment);
var project = repositoryRoot.CombineWithFilePath("src/DiabloSharp/DiabloSharp.csproj");
var testProject = repositoryRoot.CombineWithFilePath("tests/DiabloSharp.Tests/DiabloSharp.Tests.csproj");
var sampleProject = repositoryRoot.CombineWithFilePath("samples/DiabloSharp.Sample/DiabloSharp.Sample.csproj");
var artifactsDirectory = repositoryRoot.Combine("artifacts");
var outDirectory = repositoryRoot.Combine("out");
var testResultsDirectory = outDirectory.Combine("test-results");
var defaultMSBuildSettings = new DotNetCoreMSBuildSettings
{
    NoLogo = true,
    MaxCpuCount = 0
};

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
.Does(() =>
{
    Information($"Cleaning {artifactsDirectory}");
    CleanDirectory(artifactsDirectory);

    Information($"Cleaning {outDirectory}");
    CleanDirectory(outDirectory);

    var cleanSettings = new DotNetCoreCleanSettings
    {
        Configuration = configuration,
        MSBuildSettings = defaultMSBuildSettings,
        Verbosity = DotNetCoreVerbosity.Minimal
    };

    Information($"Cleaning {project}");
    DotNetCoreClean(project.FullPath, cleanSettings);

    Information($"Cleaning {testProject}");
    DotNetCoreClean(testProject.FullPath, cleanSettings);

    Information($"Cleaning {sampleProject}");
    DotNetCoreClean(sampleProject.FullPath, cleanSettings);
});

Task("Compile")
.Does(() =>
{
    var buildSettings = new DotNetCoreBuildSettings
    {
        Configuration = configuration,
        MSBuildSettings = defaultMSBuildSettings,
        Verbosity = DotNetCoreVerbosity.Minimal
    };

    DotNetCoreBuild(project.FullPath, buildSettings);
    DotNetCoreBuild(testProject.FullPath, buildSettings);
    DotNetCoreBuild(sampleProject.FullPath, buildSettings);
});

Task("Coverage")
.IsDependentOn("Compile")
.Does(() =>
{
    SetMiniCoverToolsProject(repositoryRoot.CombineWithFilePath("tools/MiniCover/MiniCover.csproj"));

    MiniCover(tool =>
        tool.DotNetCoreTest(testProject.FullPath, new DotNetCoreTestSettings
        {
            Configuration = configuration,
            Logger = "junit",
            ArgumentCustomization = args =>
            {
                args.AppendMSBuildSettings(defaultMSBuildSettings, Context.Environment);
                return args;
            },
            ResultsDirectory = testResultsDirectory,
            NoRestore = true,
            NoBuild = true,
            Verbosity = DotNetCoreVerbosity.Normal
        }),
        new MiniCoverSettings()
            .WithMiniCoverWorkingDirectory(repositoryRoot)
            .WithAssembliesMatching("tests/**/*.dll")
            .WithSourcesMatching("src/**/*.cs")
            .WithNonFatalThreshold()
            .GenerateReport(ReportType.CONSOLE | ReportType.OPENCOVER)
    );
});

Task("Package")
.IsDependentOn("Compile")
.Does(() =>
{
    DotNetCorePack(project.FullPath, new DotNetCorePackSettings
    {
        Configuration = configuration,
        NoBuild = true,
        NoRestore = true,
        IncludeSymbols = true,
        ArgumentCustomization = args => args.Append($"/p:BuildType={buildType}"),
        MSBuildSettings = defaultMSBuildSettings,
        OutputDirectory = artifactsDirectory,
        Verbosity = DotNetCoreVerbosity.Minimal
    });
});

Task("NuGetPush")
.WithCriteria(GitLabCI.IsRunningOnGitLabCI)
.IsDependentOn("Package")
.Does(() =>
{
    var pushSettings = new DotNetCoreNuGetPushSettings
    {
        Source = "nuget.org",
        ApiKey = EnvironmentVariable("DiabloSharpNuGetApiKey")
    };
    var nugetPackage = GetFiles(artifactsDirectory.GetFilePath("*.nupkg").FullPath).First();

    DotNetCoreNuGetPush(nugetPackage.FullPath, pushSettings);
});

Task("Default")
.IsDependentOn("Clean")
.IsDependentOn("Coverage")
.IsDependentOn("Package");

Task("Publish")
.WithCriteria(GitLabCI.IsRunningOnGitLabCI)
.IsDependentOn("Clean")
.IsDependentOn("Package")
.IsDependentOn("NuGetPush");

RunTarget(target);
