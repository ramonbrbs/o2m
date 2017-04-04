using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WS
{
    public class WSResponse<TEntity> where TEntity : class
    {
        public WSResponse()
        {
            Errors = new List<string>();
        }
        public TEntity Content { get; set; }
        public bool Success { get; set; }
        public List<String> Errors { get; set; }
    }
}
