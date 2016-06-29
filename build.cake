//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

#tool "nuget:?package=NUnit.ConsoleRunner"

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Get whether or not this is a local build.
var local = BuildSystem.IsLocalBuild;
var isRunningOnUnix = IsRunningOnUnix();
var isRunningOnWindows = IsRunningOnWindows();
var isRunningOnAppVeyor = AppVeyor.IsRunningOnAppVeyor;
var isPullRequest = AppVeyor.Environment.PullRequest.IsPullRequest;

Task("Restore-NuGet-Packages")
    //.IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore("./nunit-tests.sln", new NuGetRestoreSettings {
        Source = new List<string> {
            "https://www.nuget.org/api/v2/",
            "https://www.myget.org/F/nunit/api/v2"
        }
    });
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    if(isRunningOnUnix)
    {
        XBuild("./nunit-tests.sln", new XBuildSettings()
            .SetConfiguration("Debug")
            .WithProperty("TreatWarningsAsErrors", "true")
            .SetVerbosity(Verbosity.Minimal)
        );
    }
    else
    {
        MSBuild("./nunit-tests.sln", new MSBuildSettings()
            .SetConfiguration(configuration)
            .WithProperty("TreatWarningsAsErrors", "true")
            .SetVerbosity(Verbosity.Minimal)
            .SetNodeReuse(false)
        );
    }
});

Task("Test-nunit-v2")
    .IsDependentOn("Build")
    .Does(() =>
{
    NUnit3("./nunit-v2/bin/" + configuration + "/nunit-v2.dll",
        new NUnit3Settings {
            Results = "TestResults-v2.xml",
            ResultFormat = "nunit2"
        });
});

Task("Test-nunit-v3")
    .IsDependentOn("Build")
    .Does(() =>
{
    NUnit3("./nunit-v3/bin/" + configuration + "/nunit-v3.dll");
    //StartProcess("tools/NUnit.Console/tools/nunit3-console.exe", "./nunit-v3/bin/" + configuration + "/nunit-v3.dll");
});

Task("Test-nunitlite-v3")
    .IsDependentOn("Build")
    .Does(() =>
{
});

Task("Test-nunit-v3-clr")
    .IsDependentOn("Build")
    .Does(() =>
{
});

Task("Test")
    .IsDependentOn("Test-nunit-v2")
    .IsDependentOn("Test-nunit-v3")
    .IsDependentOn("Test-nunitlite-v3")
    .IsDependentOn("Test-nunit-v3-clr");

Task("Default")
  .IsDependentOn("Test");

RunTarget(target);