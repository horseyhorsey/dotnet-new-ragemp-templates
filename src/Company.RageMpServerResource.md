# Server Resource Project

---

##	dotnet new rage-serverproj --help
---


## dotnet new rage-serverproj

This template creates a RAGE-MP server resource project (defaulted to netcoreapp2.2). 

The settings.xml is added as a link in the project to easily add this new templated resource and debugging is setup to the server.exe.

***Use -n to specify name for the folder and resource to create.***

	dotnet new rage-serverproj -n BeastServerResourceProject


### Params
### serverdir : Not required but defaults to C:/RAGEMP/

This sets to server.exe for debugging. **(Use / for path seperator)**


	dotnet new rage-serverproj -n BeastServerResourceProject

Add script type **gamemode**

	dotnet new rage-serverproj -n BeastServerResourceProject -s gamemode

## meta.xml

Created and points to:

	<script src="BeastServerResourceProject.dll" />


---
# Build Information

When building the server project the build events are set to only copy the following:

	bridge/resources/
		$(TargetName)/
	 		meta.xml
	 		$(TargetName).dll
	 		$(TargetName).pdb		

Shared resources are probably better off in

	bridge/runtime  