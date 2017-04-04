using System.Collections.Generic;

namespace O2MLeads.Model
{
    public class Paginacao<TEntity> where TEntity : class
    {
        public int QtdPags { get; set; }
        public IEnumerable<TEntity> Result { get; set; }
        public int CurrentPage { get; set; }
        
    }
}
