# Server Scripts

## Params

Create a new **script** with meta.xml

	dotnet new rage-serverscript -n BeastServerScript

Create a Script of type **gamemode**	

	dotnet new rage-serverscript -n BeastServerScript -s gamemode	

Files created:

	BeastServerScript
		- meta.xml
		- BeastServerScript.cs

Use **-g false** to not generate the meta.xml

	dotnet new rage-serverscript -n BeastServerScript -g false