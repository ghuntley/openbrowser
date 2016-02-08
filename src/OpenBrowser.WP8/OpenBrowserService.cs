using System;
using System.Threading.Tasks;
using Microsoft.Phone.Tasks;

namespace OpenBrowser.WP8
{
    public class OpenBrowserService : IOpenBrowserService
    {
        /// <summary>
        /// Opens the supplied Uri in the default browser.
        /// </summary>
        public Task OpenDefaultBrowser(Uri uri)
        {
            var webBrowserTask = new WebBrowserTask() {Uri = uri};
            webBrowserTask.Show();

            return Task.FromResult(true);
        }
    }
}
