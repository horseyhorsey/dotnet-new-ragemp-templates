# RageMp Server / Client side Solution

This is for creating a solution anywhere but linked to your RAGEMP install path when building. All debugging etc is setup and ready to go.

**NOTE:** ***Use / for rage install path to steer clear of json errors***

---

### Generate solution

This generates a visual studio solution with projects needed.
	
	dotnet new rage-solution -r "E:/RAGEMP" -s MyBeastSolution

This generates a visual studio solution with projects needed and specifying a directory.

	dotnet new rage-solution -r "E:/RAGEMP" -s MyBeastSolution -n MyBeastSolution


**Params:**

	-r Rage install path
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

### Server-Side
When the Server builds, it will only copy the needed references to:

	{RAGEMP_InstallDir}\server-files\bridge\resources\MyBeastSolution.Server

This is referenced in the meta.xml:

	<script src="MyBeastSolution.Server.dll" /> 

### Client-Side

On building, only the .cs are copied. Folders containing .cs files are also copied like the example above, **MyBeastSolution.Client\MyFirstScript**

The csharp files are copied to:

	{RAGEMP_InstallDir}\server-files\client_packages\cs_packages\MyBeastSolution.Client

### Client-Side Web

Made as an existing Website that contains a publishing profile. The published contents go into:

	{rageinstallpath}\server-files\client_packages\MyBeastSolution_UI
