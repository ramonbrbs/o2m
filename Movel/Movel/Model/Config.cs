using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Movel.Model
{
    [Table("CONFIG")]
    public class Config
    {
        [PrimaryKey]
        public int CodConfig { get; set; }

        public int CodParceiro { get; set; }
    }
}
