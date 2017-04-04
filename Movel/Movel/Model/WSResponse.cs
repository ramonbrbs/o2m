using System;
using System.Collections.Generic;

namespace Movel.Model
{
    public class WSResponse<T> where T : class 
    {
        public T Content { get; set; }
        public bool Success { get; set; }
        public List<String> Errors { get; set; }
    }
}
