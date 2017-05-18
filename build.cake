#tool "nuget:?package=GitVersion.CommandLine"
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");


var solution = "./DiscordRest.sln";
var netstandard = "netstandard1.0";

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var projects = GetFiles("./**/*.csproj");
var buildArtifacts = Directory("./artifacts/packages");
GitVersion versionInfo = null;

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("GetVersion")
	.Does(() => 
{
	versionInfo = GitVersion();
	Information(versionInfo.NuGetVersionV2);
});

Task("Clean")
    .Does(() =>
{
	Information("Cleaning artifacts");
    CleanDirectory(buildArtifacts);
	Information("Cleaning source bin");
	foreach(var project in projects)
	{
		CleanDirectories(project.GetDirectory().FullPath + "/bin/**");
		CleanDirectories(project.GetDirectory().FullPath + "/obj/**");
	}
});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    foreach(var project in projects) 
	{
		DotNetCoreRestore(project.GetDirectory().FullPath);		
	}
});

Task("Build")
    .IsDependentOn("Restore")
	.IsDependentOn("GetVersion")
    .Does(() =>
{

	DotNetBuild(solution, settings => settings.SetConfiguration(configuration)
		.WithProperty("VersionPrefix", versionInfo.MajorMinorPatch)
		.WithProperty("VersionSuffix", versionInfo.PreReleaseLabel + versionInfo.PreReleaseNumber)
		.WithProperty("OutputPath", "../../artifacts/packages")
	);
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
	var projects = GetFiles("./test/**/*.csproj");
    foreach(var project in projects)
    {
		var arguments = new ProcessArgumentBuilder();
		arguments.Append("/c dotnet xunit -xml ");
		arguments.Append(project.ChangeExtension("xml").ToString());
		using(var process = StartAndReturnProcess("cmd", new ProcessSettings { 
			WorkingDirectory = project.GetDirectory().FullPath,
			Arguments = arguments
		})) 
		{
			process.WaitForExit();
		}
	}
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Build")
	.IsDependentOn("Test");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
