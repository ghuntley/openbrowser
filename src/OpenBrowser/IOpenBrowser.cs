using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBrowser
{
    public interface IOpenBrowser
    {
        Task OpenDefaultBrowser(Uri uri);
    }
}