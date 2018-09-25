OBS Frame Filter and Folder Syncing Toolkit
-------------------------------------------

OBS filter: repeating-frame-capture-filter.dll (x64)

- Needs to be copied to OBS plugin folder
(such as "C:\Program Files (x86)\obs-studio\obs-plugins\64bit")
- Needs to be added as a filter to chosen source

Functionality/Usage:
When active starts to create images under C:\RepeatingFilter\Captures
(might be required to create the directories for it, if the OBS running permissions do not suffice for creating them)



FrameFolderSyncTool.dll (.NET Core Application)
- Requires .NET Core Runtime 2.1 (Runtime should be enough, no need for SDK)
https://www.microsoft.com/net/download/dotnet-core/2.1

Functionality/Usage:
- Using .NET Core Runtime "dotnet" command to run
- Use normal command line or .bat/.cmd file 
dotnet FrameFolderSyncTool.dll <source captures folder> <target captures folder>

Example (running from other computer to access the C:\RepeatingFilter\Captures through named source "RepeatingFilter"):

dotnet FrameFolderSyncTool.dll \\SourceComputer\RepeatingFilter\Captures\ C:\What\Ever\Path\That\Ends\With\Captures\


When working, should stay open and move all folders that have "done" file with them named accordingly to target location and removing them as moved from the source. Ctrl + C ends the program when running.

DISCLAIMER: No warranties - use at your own risk.