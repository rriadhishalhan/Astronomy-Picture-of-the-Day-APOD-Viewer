# NASA APOD Viewer

NASA APOD Viewer is an ASP.NET Core MVC application that showcases NASA's Astronomy Picture of the Day (APOD). Browse today's highlight, search the archive by date, and learn more about each capture through NASA's official API.

## Features
- Responsive Bootstrap 5 UI tailored for desktops and mobile devices
- Displays APOD title, date, description, and high-resolution media when available
- Date picker to explore past Astronomy Picture of the Day entries
- Graceful error handling for missing images, non-image media, or API issues
- Configurable NASA API key stored securely in `appsettings.json`

## Tech Stack
- .NET 7 (ASP.NET Core MVC)
- C# 11
- Bootstrap 5
- NASA Astronomy Picture of the Day API

## Getting Started

### Prerequisites
- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download)
- A NASA API key (request one at [api.nasa.gov](https://api.nasa.gov/))

### Setup
1. Clone the repository and navigate into the project folder:
   ```bash
   git clone <your-fork-url>
   cd Astronomy-Picture-of-the-Day-APOD-Viewer
   ```
2. Add your NASA API key to `appsettings.json` (or `appsettings.Development.json`, which is git-ignored):
   ```json
   {
     "NasaApi": {
       "BaseUrl": "https://api.nasa.gov/planetary/apod",
       "ApiKey": "YOUR_API_KEY_HERE"
     }
   }
   ```
3. Restore packages and run the application:
   ```bash
   dotnet restore
   dotnet run
   ```
4. Visit `https://localhost:5001` (or the URL printed in the console) to view the app.

### Running Tests
This starter project does not ship with automated tests. Add unit or integration tests as the app grows, especially around API integration and controller logic.

## Screenshot / Demo
> _Add screenshots or animated GIFs here once the UI is finalized._

## Roadmap
- Support for NASA's APOD video entries with in-app playback
- Offline caching of recent APOD responses
- Light/dark theme toggle and accessibility improvements
- Internationalization and localization support

## License
Distributed under the MIT License. See `LICENSE` for more information.
