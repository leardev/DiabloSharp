///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
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
        OutputDirectory = artifactsDirectory,
        Verbosity = DotNetCoreVerbosity.Minimal
    });
});

Task("Default")
.IsDependentOn("Clean")
.IsDependentOn("Test")
.IsDependentOn("Package");

RunTarget(target);
