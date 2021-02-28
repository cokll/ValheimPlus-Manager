# ValheimPlus Manager
ValheimPlus Manager makes the installation and configuration of ValheimPlus on Windows a breeze!
## Features
- Automatically install ValheimPlus to your game client or server client directory
- Manage the configuration of ValheimPlus through a GUI
- Update ValheimPlus directly through ValheimPlus Manager
- Keep settings from previous versions and just add/activate new settings automagically
- Enable/disable ValheimPlus on game client, so you can join non-modded servers on the fly
- Launch Valheim(Plus) from the Manager
- In-app settings of installation paths (ToDo: server paths)
## Roadmap
- UI cleanups and corrections
- Server list manager, join servers from the Manager
- Backup your configuration files
- Backup your game client and server client data
- Management of server admins
- Uninstall ValheimPlus from game client/server client
## Requirements
.NET 5 available for download at: https://dotnet.microsoft.com/download/dotnet/5.0/runtime
## Installation
- Download the pre-built project from the releases tab, unzip the .zip archive
- In Data/Settings.xml open the Settings.xml file and replace the installation paths with your own
- Start the manager through the .exe file
## Known issues
- If using a VPN where your assigned IP has been polling the Github API over 60 times in the last hour an error will be thrown. Try changing your VPN IP-address or disabling your VPN when checking for updates.
- On first launch/before first update through the manager the installed version reported might be incorrect, waiting for ValheimPlus dev to implement easy way to check current version.
## Building the project
Just download the source code, open in Visual Studio 2019 and restore the NuGet packages. Hit F5 to start running/debugging the project.
### Donations
Wanna buy me a cup of coffee?

Ethereum (ETH): 0xAC7E1beC00A3a26C623a73A3974e91f7b8A463b9