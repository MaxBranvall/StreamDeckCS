@echo on

:: This script eases building and installing your Stream Deck plugin using the Stream Deck Distribution Tool.
:: For convienence, tool will be included with this project.
:: Get the tool from https://developer.elgato.com/documentation/stream-deck/sdk/packaging/

:: User variables
:: path to DistributionTool.exe
SET DistributionToolPath=".\DistributionTool.exe"

:: where your .sdPlugin file will be built to
SET pluginReleasePath=".\Release"

:: path to build files, typically under your projects bin/debug or bin/release directories
SET buildDirectoryPath="..\com.mbranvall.sdcs-sample.sdPlugin\Debug\net5.0"

:: Path to your com.{YOUR_USER}.{YOUR_PLUGIN}.sdPlugin directory within your project folder
SET sdPluginPath="..\com.mbranvall.sdcs-sample.sdPlugin"

:: path to directory which includes your project's .csproj file
SET projectPath="..\"

:: Script

:: build project
dotnet build %projectPath%

:: timeout to avoid errors
timeout /t 5

:: Copy contents of debug folder to .sdPlugin folder
robocopy /s %buildDirectoryPath% %sdPluginPath%

:: Clear out existing files for replacement
rmdir /s /q %buildDirectoryPath%
rmdir /s /q %pluginReleasePath%

:: create our release directory
mkdir %pluginReleasePath%

:: run the distribution tool, change to release path, and open our new plugin
%DistributionToolPath% -b -i %sdPluginPath% -o %pluginReleasePath%
cd %pluginReleasePath%
com.mbranvall.sdcs-sample.streamDeckPlugin
