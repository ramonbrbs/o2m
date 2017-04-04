using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Paginacao<TEntity> where TEntity : class
    {
        public int QtdPags { get; set; }
        public IEnumerable<TEntity> Result { get; set; }
        public int CurrentPage { get; set; }
        
    }
}
