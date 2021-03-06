#module nuget:?package=Cake.DotNetTool.Module&version=0.4.0
#tool dotnet:?package=MiniCover&version=3.0.6

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
        ArgumentCustomization = args => args.Append("/v:m"),
        MSBuildSettings = defaultMSBuildSettings
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
    if (GitLabCI.IsRunningOnGitLabCI)
    {
        var latestSha = GitLabCI.Environment.Build.Reference;
        defaultMSBuildSettings.WithProperty("RevisionId", latestSha);
    }

    var buildSettings = new DotNetCoreBuildSettings
    {
        Configuration = configuration,
        ArgumentCustomization = args => args.Append("/v:m"),
        MSBuildSettings = defaultMSBuildSettings
    };

    DotNetCoreBuild(project.FullPath, buildSettings);
    DotNetCoreBuild(testProject.FullPath, buildSettings);
    DotNetCoreBuild(sampleProject.FullPath, buildSettings);
});

Task("Coverage")
.IsDependentOn("Compile")
.Does(() =>
{
    var miniCoverPath = IsRunningOnUnix() ? Context.Tools.Resolve("minicover") : Context.Tools.Resolve("minicover.exe");

    StartProcess(miniCoverPath, $"instrument --workdir={repositoryRoot} --sources=src/**/*.cs --tests=tests/**/*.dll");
    StartProcess(miniCoverPath, "reset");

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
        NoRestore = true,
        NoBuild = true
    });

    StartProcess(miniCoverPath, "uninstrument");
    StartProcess(miniCoverPath, $"report --workdir={repositoryRoot} --threshold 0");
    StartProcess(miniCoverPath, $"opencoverreport --workdir={repositoryRoot} --threshold 0");
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
        ArgumentCustomization = args =>
        {
            args.Append($"/p:BuildType={buildType}");
            args.Append("/v:m");
            return args;
        },
        MSBuildSettings = defaultMSBuildSettings,
        OutputDirectory = artifactsDirectory
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
