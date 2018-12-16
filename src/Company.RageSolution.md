# RageMp Server / Client side Solution

This is for creating a solution anywhere but linked to your RAGEMP install path when building.

### Generate solution
	
	dotnet new rage-solution -r "E:\RAGEMP" -s MyBeastSolution

	-r Rage install path
	-s Solution Name

This generates a visual studio solution with projects needed.

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


### Server-Side
When the Server builds, it will only copy the needed references to:

	{RAGEMP_InstallDir}\server-files\bridge\resources\MyBeastSolution.Server

This is referenced in the meta.xml:

	<script src="MyBeastSolution.Server.dll" /> 

### Client-Side

On building, only the .cs are copied. Folders containing .cs files are also copied like the example above, **MyBeastSolution.Client\MyFirstScript**

The csharp files are copied to:

	{RAGEMP_InstallDir}\server-files\client_packages\cs_packages\MyBeastSolution.Client