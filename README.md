## Description

Project “Search engine”.

This project is a C# WPF application that utilizes the Google API to perform searches and display search results on the screen. It provides users with the ability to enter a search query, process it using the Google API, and view the resulting website listings. Additionally, it incorporates the functionality of IE to allow users to navigate and explore the websites directly from the application.

## Installation

1. Clone the repository: 
    ```bash
    git clone https://github.com/md3grw/.NET-WPF-SearchEngine.git
2. Set up the .env file(Google API (check the Config.cs file))
3. Open .csproj file in your IDE

*NuGet packages that are used:
- DotNetEnv
- Google.Apis.Customsearch.v1
- Microsoft.Extensions.Configuration
- Microsoft.Extensions.Configuration.EnvironmentVariables
- Microsoft.Extensions.Configuration.UserSecrets
- Microsoft.Web.WebView2

*If you are having problems launching app for the first time, changing <ImageBrush ImageSource="../images/github.png"/> in MainWindow.xaml for an absolute path will help you.

## License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).