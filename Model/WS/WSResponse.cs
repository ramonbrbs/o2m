using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WS
{
    public class WSResponse
    {
        public object Content { get; set; }
        public bool Success { get; set; }
        public List<String> Errors { get; set; }
    }
}
