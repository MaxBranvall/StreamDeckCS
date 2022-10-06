@echo on

:: This script eases development and debugging of Stream Deck plugins. Simply run this script
:: and your plugin will be copied to the Stream Deck plugins directory and will be available
:: in Stream Deck software.

:: User variables
:: path to directory which includes your project's .csproj file
SET projectPath="..\"

:: path to build files, typically under your projects bin/debug or bin/release directories
SET buildDirectoryPath="..\com.mbranvall.sdcs-sample.sdPlugin\Debug\net5.0"

:: path to your plugin's Stream Deck directory
:: ex: "C:\Users\{USER}\AppData\Roaming\Elgato\StreamDeck\Plugins\com.USER.pluginName.sdPlugin" 
SET sdPluginPath="C:\Users\maxbr\AppData\Roaming\Elgato\StreamDeck\Plugins\com.mbranvall.sdcs-sample.sdPlugin"

:: SCript

:: Close Stream Deck app
Taskkill /f /im streamdeck.exe

:: build project
dotnet build %projectPath%

:: timeout to avoid errors
timeout /t 5

:: Copy contents of debug folder to .sdPlugin folder
robocopy /s %buildDirectoryPath% %sdPluginPath%

:: start Stream Deck app
Start "" "C:\Program Files\Elgato\StreamDeck\StreamDeck.exe"
