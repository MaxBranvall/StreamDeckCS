# StreamDeckCS

A C# Stream Deck API wrapper developed for ease of use without sacrifice, giving developers complete freedom in their plugin design and the ability to utilize every feature currently available in the Stream Deck API.

[StreamDeck API for reference](https://developer.elgato.com/documentation/stream-deck/sdk/overview/)

<!-- GETTING STARTED -->
## Getting Started

## Resources

To ease development, I recommend grabbing manifest.json from the sample plugin, modifying it, and 
placing it in your root project directory. Also, I have included a couple batch scripts to ease development. Refer to the comments in the scripts
themselves for descriptions on what they do and how they work. 
<br/>
1. SamplePlugin/resources/sdInstallDev.bat
2. SamplePlugin/resources/sdInstallProd.bat

<!-- USAGE EXAMPLES -->
## Usage

In order to use this wrapper in your plugin, follow these simple steps. <br/>
Note: If you encounter any confusion, refer to the SamplePlugin in this repo.

#### Option 1

1. Clone this repo and modify the SamplePlugin, more details for that will be included in the SamplePlugin README

#### Option 2

1. Create a new C# project of type Console App.
2. Configuration
   1. Right click the project, select properties, change output type to Windows Application
   2. Don't forget a manifest.json, this can be taken from the SamplePlugin and modified for convenience
3. Install StreamDeckCS from Nuget package manager
4. At the top of Program.cs, type ``` using System.Threading.Tasks; ``` and ``` Using StreamDeckCS; ```
5. Modify the Main method to ```static async Task Main(string[] args)```
6. In the method type <br/> 
   ```cs
    StreamdeckCore core = new StreamdeckCore(args);
    await core.Start();
   ```
7. That's it! Obviously, there is no functionality here. So we can subscribe to any events with <br/>
    ```cs
    StreamdeckCore core = new StreamdeckCore(args);
    core.KeyDownEvent += Core_KeyDownEvent;
    await core.Start();
   ```
8. Now, we can add functionality whenever a KeyDown event is raised, i.e when a button is pressed.
9. All events and features supported by the Stream Deck API are available in this wrapper.
10. Refer to the SamplePlugin as well as my full fledged plugin [WinMixerDeck](https://github.com/MaxBranvall/WinMixerDeck).


<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<!-- CONTACT -->
## Contact

Max Branvall - maxbranvalldevelopment@gmail.com

Project Link: [https://github.com/maxbranvall/streamdeckcs](https://github.com/maxbranvall/streamdeckcs)




<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* [Thanks othneildrew for the awesome ReadME template!](https://github.com/othneildrew/Best-README-Template)
