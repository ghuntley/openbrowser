using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBrowser
{
    public interface IOpenBrowserService
    {
        Task OpenDefaultBrowser(Uri uri);
    }
}