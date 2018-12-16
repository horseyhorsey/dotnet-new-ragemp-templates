# Server Resource Project

You should run the server commands inside your resources folder. **RAGEMP\server-files\bridge\resources** . 

### rage-serverproj

This template creates a RAGE-MP server resource project (defaulted to netcoreapp2.0). 
The settings.xml is added as a link in the project to easily add this new templated resource and debugging is setup to the server.exe.

***Use -n to specify name for the folder and resource to create.***

	dotnet new rage-serverproj -n BeastServerResourceProject


### Params
### serverdir : Not required but defaults to E:/RAGEMP/server-files

This sets to server.exe for debugging. **(Use / for path seperator)**


	dotnet new rage-serverproj -n BeastServerResourceProject -serverdir "C:/RAGEMP/server-files"

### Build output folder - Not required: defaults to build/netcoreapp2.0

Specify output folder. 	

	dotnet new rage-serverproj -n BeastServerResourceProject -serverdir "C:/RAGEMP/server-files" -b build

This will edit the meta.xml:

	<script src="build/netcoreapp2.0/BeastServerResourceProject.dll" />

### Framework - Not required and server currently using 2.0

See framework choices in general help
	
	dotnet new rage-serverproj -h
