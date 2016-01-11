![Icon](https://i.imgur.com/cLe0zZj.png)
# OpenBrowser

OpenBrowser is a super simple library that does one thing and does it well. It  does exactly what the name entails, a cross-platform pattern for launching the default browser on a mobile/tablet device from a portable class library viewmodel. In the future, if demand exists the interface may be extended to add support for browsers other than the default browser.

# Supported Platforms

* Xamarin iOS
* Xamarin Android
* Universal Windows Platform
* Windows Phone 8.x

# Installation
Installation is done via NuGet:

    PM> Install-Package OpenBrowser
    
# Usage

The following example demonstrates how to use the library with ReactiveUI/splat but you can use the library with anything as there are no dependancies. The signature of the library is as follows

    Task OpenDefaultBrowser(Uri uri);

Register the platform specific implementation at application startup

    Locator.CurrentMutable.RegisterConstant(() => new OpenBrowser, typeof(IOpenBrowser)
    
In your portable class library (core) implementation

    private readonly IOpenBrowser _openBrowser;
    public ReactiveCommand OpenBrowser { get; }
     
    public class MyCoolViewModel(IOpenBrowser openBrowser = null)
    {
        _openBrowser = openBrowser ?? Locator.Current.GetService<IBrowser>();   
        
        OpenBrowser = ReactiveCommand.CreateAsyncTask(async x () =>
        {
            await _openBrowser.OpenDefaultBrowser(Uri uri);
        }
    }

# With thanks to
* The icon "[Search](https://thenounproject.com/term/search/161446/)" designed by [Calvin Goodman](https://thenounproject.com/calpoog/) from The Noun Project.