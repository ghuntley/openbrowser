![Icon](https://i.imgur.com/cLe0zZj.png)
# OpenBrowser

OpenBrowser is a super simple library that does one thing and does it well. It does exactly what the name entails, a cross-platform pattern for launching the default browser on a mobile/tablet device from a portable class library viewmodel. In the future, if demand exists the interface may be extended to add support for browsers other than the default browser.

# Supported Platforms

* Xamarin iOS
* Xamarin Android
* Universal Windows Platform
* Windows Phone 8.x
* Windows Store 8.x

# Installation

Installation is done via NuGet:

    PM> Install-Package OpenBrowser
    
# Usage

The following example demonstrates how to use the library with ReactiveUI/splat but you can use the library with anything as there are no dependancies. The signature of the library is as follows

    Task OpenDefaultBrowser(Uri uri);

Register the platform specific implementation at application startup

    Locator.CurrentMutable.RegisterLazySingleton(() => new OpenBrowserService, typeof(IOpenBrowserService)
    
In your portable class library (core) implementation

    private readonly IOpenBrowserService _openBrowserService;
    private string _websiteAddress = string.Empty;
    
	public ReactiveCommand OpenWebPage { get; protected set; }

    public string WebsiteAddress
    {
        get { return _websiteAddress; }
        set { this.RaiseAndSetIfChanged(ref _websiteAddress, value); }
    }
     
    public class MyCoolViewModel(IOpenBrowserService openBrowserService = null)
    {
        _openBrowserService = openBrowserService ?? Locator.Current.GetService<IBrowserService>();   
        
        OpenWebPage = ReactiveCommand.CreateAsyncTask(async x () =>
        {
            await _openBrowserService.OpenDefaultBrowser(WebsiteAddress);
        }
    }

# With thanks to

* The icon "[Search](https://thenounproject.com/term/search/161446/)" designed by [Calvin Goodman](https://thenounproject.com/calpoog/) from The Noun Project.