#tool "nuget:?package=GitVersion.CommandLine"
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");


var solution = "./DiscordRest.sln";
var netstandard = "netstandard1.3";

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var projects = GetFiles("./**/*.csproj");
var buildArtifacts = Directory("./artifacts");
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


	MSBuild(solution, config => 
		config.SetVerbosity(Verbosity.Minimal)
			.SetConfiguration(configuration)
			.WithProperty("VersionPrefix", versionInfo.MajorMinorPatch)
			.WithProperty("VersionSuffix",versionInfo.NuGetVersionV2.Remove(0, versionInfo.NuGetVersionV2.IndexOf("-")+1))
			.UseToolVersion(MSBuildToolVersion.VS2017));
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

Task("CopyArtifacts")
	.IsDependentOn("Build")
	.Does(() => {
		CopyFiles("./src/**/bin/"+configuration+"/**/*.*", buildArtifacts);
	});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Build")
	.IsDependentOn("Test")
	.IsDependentOn("CopyArtifacts");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
