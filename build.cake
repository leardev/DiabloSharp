///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var buildType = Argument("buildtype", "dev");
var project = new FilePath(@"./src/DiabloSharp/DiabloSharp.csproj");
var testProject = new FilePath(@"./tests/DiabloSharp.Tests/DiabloSharp.Tests.csproj");
var artifactsDirectory = new DirectoryPath(@"./artifacts");

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
.Does(() =>
{
    Information($"Cleaning {artifactsDirectory}");
    CleanDirectory(artifactsDirectory);
    var cleanSettings = new DotNetCoreCleanSettings
    {
        Configuration = configuration,
        Verbosity = DotNetCoreVerbosity.Minimal
    };

    Information($"Cleaning {project}");
    DotNetCoreClean(testProject.FullPath, cleanSettings);

    Information($"Cleaning {testProject}");
    DotNetCoreClean(testProject.FullPath, cleanSettings);
});

Task("Test")
.Does(() =>
{
    DotNetCoreTest(testProject.FullPath, new DotNetCoreTestSettings
    {
        Configuration = configuration,
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
.IsDependentOn("Package");

Task("Publish")
.WithCriteria(GitLabCI.IsRunningOnGitLabCI)
.IsDependentOn("Clean")
.IsDependentOn("Package")
.IsDependentOn("NuGetPush");

RunTarget(target);
