using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2MLeads.Model
{
    public class WSResponse<T> where T : class 
    {
        public T Content { get; set; }
        public bool Success { get; set; }
        public List<String> Errors { get; set; }
    }
}
