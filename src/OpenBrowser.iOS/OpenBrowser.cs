using System;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace OpenBrowser.iOS
{
    public class OpenBrowser : IOpenBrowser
    {
        /// <summary>
        /// Opens the supplied Uri in the default browser.
        /// </summary>
        public Task OpenDefaultBrowser(Uri uri)
        {
            UIApplication.SharedApplication.OpenUrl(new NSUrl(uri.ToString()));

            return Task.FromResult(true);
        }
    }
}