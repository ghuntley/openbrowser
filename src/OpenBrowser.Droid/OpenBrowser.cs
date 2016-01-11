using System;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;


namespace OpenBrowser.Droid
{
    /// <summary>
    /// Opens the supplied Uri in the default browser.
    /// </summary>
    public class OpenBrowser : Activity, IOpenBrowser
	{
		public Task OpenDefaultBrowser(System.Uri uri)
		{
			var intent = new Intent (Intent.ActionView, Android.Net.Uri.Parse(uri.ToString()));
		    StartActivity(intent);

            return Task.FromResult(true);
        }
    }
}


