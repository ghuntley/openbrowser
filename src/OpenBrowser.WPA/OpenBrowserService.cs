using System;
using System.Threading.Tasks;
using Windows.System;

namespace OpenBrowser.WPA
{
    public class OpenBrowserService : IOpenBrowserService
    {
        /// <summary>
        ///     Opens the supplied Uri in the default browser.
        /// </summary>
        public async Task OpenDefaultBrowser(Uri uri)
        {
            await Launcher.LaunchUriAsync(uri);
        }
    }
}