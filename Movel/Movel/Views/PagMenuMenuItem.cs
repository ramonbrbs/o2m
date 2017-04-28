using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movel.Views
{

    public class PagMenuMenuItem
    {
        public PagMenuMenuItem()
        {
            TargetType = typeof(PagMenuDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
