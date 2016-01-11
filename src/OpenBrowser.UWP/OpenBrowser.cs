using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace OpenBrowser.UWP
{
    public class OpenBrowser : IOpenBrowser
    {
        /// <summary>
        /// Opens the supplied Uri in the default browser.
        /// </summary>
        public async Task OpenDefaultBrowser(Uri uri)
        {
            await Launcher.LaunchUriAsync(uri);
        }
    }
}
