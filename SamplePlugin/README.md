# SamplePlugin

This is a sample plugin developed using StreamDeckCS. It creates an action under the category SDCS_Sample. This action allows
users to click a button which increments a counter and generates the next number from the Fibonacci sequence. Users can also
hold the button for two seconds to reset this counter.

[StreamDeck API for reference](https://developer.elgato.com/documentation/stream-deck/sdk/overview/)

## Resources

I have included a couple batch scripts to ease development. Refer to the comments in the scripts
themselves for descriptions on what they do and how they work. 
<br/>
1. resources/sdInstallDev.bat
2. resources/sdInstallProd.bat

### Notes
When I am actively developing the plugin, I tend to run sdInstallDev.bat to test changes. I only use sdInstallProd.bat when I wish to create a .sdPlugin file for distribution. To ensure the scripts do not run into any errors, ensure your user variables are set correctly. If you are using sdInstallProd.bat, ensure you have incremented your plugins version number in your manifest.json from your last distribution, otherwise Stream Deck will not install it.

## Installation
How to install plugin

### Option 1
1. Download the .sdPlugin file from releases section of the repo

### Option 2
1. Clone the StreamDeckCS repo
2. Unzip the folder
3. Navigate to SamplePlugin/resources
4. Run sdInstallProd.bat
5. This builds the project, creates a .sdPlugin file, and tells Stream Deck to install it.

<!-- CONTACT -->
## Contact

Max Branvall - maxbranvalldevelopment@gmail.com

Project Link: [https://github.com/maxbranvall/streamdeckcs](https://github.com/maxbranvall/streamdeckcs)


<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* [Thanks othneildrew for the awesome ReadME template!](https://github.com/othneildrew/Best-README-Template)
