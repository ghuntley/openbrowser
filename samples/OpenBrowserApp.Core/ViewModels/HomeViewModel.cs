using System;
using System.Reactive;
using OpenBrowser;
using ReactiveUI;
using Splat;

namespace OpenBrowserApp.Core.ViewModels
{
    public class HomeViewModel : ReactiveObject, IEnableLogger
    {
        private readonly IOpenBrowserService _openBrowserService;

        private string _websiteAddress = string.Empty;

        public HomeViewModel(IOpenBrowserService openBrowserService = null)
        {
            _openBrowserService = openBrowserService ?? Locator.Current.GetService<IOpenBrowserService>();

            var isValidWebsiteAddress = this.WhenAny(x => x.WebsiteAddress, x =>
            {
                Uri result;
                return Uri.TryCreate(WebsiteAddress, UriKind.Absolute, out result);
            });

            OpenWebPage = ReactiveCommand.CreateAsyncTask(isValidWebsiteAddress,
                async _ => { await _openBrowserService.OpenDefaultBrowser(new Uri(WebsiteAddress)); });

            OpenWebPage.ThrownExceptions.Subscribe(
                ex => UserError.Throw("Does this device have a web browser installed?", ex));
        }

        public string WebsiteAddress
        {
            get { return _websiteAddress; }
            set { this.RaiseAndSetIfChanged(ref _websiteAddress, value); }
        }

        public ReactiveCommand<Unit> OpenWebPage { get; private set; }
    }
}