using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXamarin.WebRequest
{
    public class WebRequestResponseError : Exception
    {
        public WebRequestResponseError(string msg) : base(msg) { }
        public Request Request { get; set; }
    }
}
