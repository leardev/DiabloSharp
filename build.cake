///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var buildType = Argument("buildtype", "dev");
var project = new FilePath(@"./src/DiabloSharp/DiabloSharp.csproj");
var testProject = new FilePath(@"./tests/DiabloSharp.Tests/DiabloSharp.Tests.csproj");
var sampleProject = new FilePath(@"./samples/DiabloSharp.Sample/DiabloSharp.Sample.csproj");
var artifactsDirectory = new DirectoryPath(@"./artifacts");
var outDirectory = new DirectoryPath(@"./out");
var testResultsDirectory = outDirectory.Combine("test-results");
var defaultMSBuildSettings = new DotNetCoreMSBuildSettings
{
    NoLogo = true,
    MaxCpuCount = 0,
    TreatAllWarningsAs = MSBuildTreatAllWarningsAs.Error
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
    DotNetCoreClean(testProject.FullPath, cleanSettings);

    Information($"Cleaning {testProject}");
    DotNetCoreClean(testProject.FullPath, cleanSettings);

    Information($"Cleaning {sampleProject}");
    DotNetCoreClean(sampleProject.FullPath, cleanSettings);
});

Task("Test")
.Does(() =>
{
    DotNetCoreTest(testProject.FullPath, new DotNetCoreTestSettings
    {
        Configuration = configuration,
        Logger = "junit",
        ArgumentCustomization = args =>
        {
            args.AppendMSBuildSettings(defaultMSBuildSettings, Context.Environment);
            return args;
        },
        ResultsDirectory = testResultsDirectory,
        Verbosity = DotNetCoreVerbosity.Minimal
    });
});

Task("Sample")
.Does(() =>
{
    DotNetCoreBuild(sampleProject.FullPath, new DotNetCoreBuildSettings
    {
        Configuration = configuration,
        MSBuildSettings = defaultMSBuildSettings,
        Verbosity = DotNetCoreVerbosity.Minimal
    });
});

Task("Package")
.Does(() =>
{
    DotNetCorePack(project.FullPath, new DotNetCorePackSettings
    {
        Configuration = configuration,
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
    var nugetFile = GetFiles(artifactsDirectory.GetFilePath("*.nupkg").FullPath).First();
    DotNetCoreNuGetPush(nugetFile.FullPath, new DotNetCoreNuGetPushSettings
    {
        Source = "nuget.org",
        ApiKey = EnvironmentVariable("DiabloSharpNuGetApiKey")
    });
});

Task("Default")
.IsDependentOn("Clean")
.IsDependentOn("Test")
.IsDependentOn("Sample")
.IsDependentOn("Package");

Task("Publish")
.WithCriteria(GitLabCI.IsRunningOnGitLabCI)
.IsDependentOn("Clean")
.IsDependentOn("Package")
.IsDependentOn("NuGetPush");

RunTarget(target);
