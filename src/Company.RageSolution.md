# RageMp Server / Client side Solution

This is for creating a solution anywhere but linked to your RAGEMP install path when building. All debugging etc is setup and ready to go.

**NOTE:** ***Use / for rage install path to steer clear of json errors***

---

### Generate solution

This generates a visual studio solution with projects needed.
	
	dotnet new rage-solution -r "C:/RAGEMP" -s MyBeastSolution

This generates a visual studio solution with projects needed and specifying a directory.

	dotnet new rage-solution -r "C:/RAGEMP" -s MyBeastSolution -n MyBeastSolution


**Params:**

	-r Rage install path (not required)
	-n Name of directory and resource
	-s Solution Name

**Output structure:**

	MyBeastSolution
		+ Client-Side
			+ MyBeastSolution.Client (csproj)
				+ MyFirstScript
					- MyFirstScript.cs
			+ MyBeastSolution_UI (existing website)
				- (To contains all html, css etc)
				
		+ Server-Side
			+ MyBeastSolution.Server (csproj)
				- Main.cs
				- meta.xml
				- settings.xml (linked to the install path in params)


When solution is generated, open it and edit the **settings.xml** by adding

	<resource>MyBeastSolution</resource>

Now you can run the server project in debug.

---

# Projects Info

## Server-Side
---

When building the server project the build events are set to only copy the following:

	bridge/resources/
		$(TargetName)/
	 		meta.xml
	 		$(TargetName).dll
	 		$(TargetName).pdb		

Shared resources are better off in for server load up times.

	bridge/runtime  

### NOTE:

*A dummy folder is created inside server-files/resources*

This folder will allow you to use the NAPI.Resource Start/Stop etc. If loading a map the maps are loaded from here too.

---
## Client-Side

On building, only the .cs are copied. Folders containing .cs files are also copied like the example above, **MyBeastSolution.Client\MyFirstScript**

The csharp files are copied to:

	{RAGEMP_InstallDir}\server-files\client_packages\cs_packages\MyBeastSolution.Client

### Client-Side Web

Made as an existing Website that contains a publishing profile. The published contents go into:

	{rageinstallpath}\server-files\client_packages\MyBeastSolution_UI
