using System.Collections.Generic;

namespace Movel.Model
{
    public class Paginacao<TEntity> where TEntity : class
    {
        public int QtdPags { get; set; }
        public IEnumerable<TEntity> Result { get; set; }
        public int CurrentPage { get; set; }
        
    }
}
