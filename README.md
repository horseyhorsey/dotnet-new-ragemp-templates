# RAGE-MP Templates
---

## RAGEMP Setup 0.3.7
1. Download [Dotnet 2.2 runtime binaries](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.101-windows-x64-binaries)
2. Place dotnet binaries in *server-files/bridge/runtime*
3. Create empty 'enable-clientside-cs.txt' in RAGEMP
4. Install templates from command line:

		dotnet new -i RageMp.DotnetTemplates
5. Run **dotnet new** to see installed templates

---
# Commands help

## [Solution Server / Client Readme](https://github.com/horseyhorsey/dotnet-new-ragemp-templates/blob/master/src/Company.RageSolution.md)
## [Server Resource Readme](https://github.com/horseyhorsey/dotnet-new-ragemp-templates/blob/master/src/Company.RageMpServerResource.md)
## [Client Resource Readme](https://github.com/horseyhorsey/dotnet-new-ragemp-templates/blob/master/src/Company.RageMpClientResource.md)
## [Server Scripts Readme](https://github.com/horseyhorsey/dotnet-new-ragemp-templates/blob/master/src/Company.RageMpServerScript.md)
## [Client Scripts Readme](https://github.com/horseyhorsey/dotnet-new-ragemp-templates/blob/master/src/Company.RageMpClientScript.md)

---

# Install Uninstall

	dotnet new -u RageMp.DotnetTemplates
	dotnet new -u RageMp.DotnetTemplates

# Install Uninstall local
	
	dotnet new -i dotnet-new-ragemp-templates
	dotnet new -u {Full path to install}	
	