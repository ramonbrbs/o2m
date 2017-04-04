using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Banco
    {
        [Key]
        public int CodBanco { get; set; }

        public string Nome { get; set; }
        public int CodBacen { get; set; }
    }
}
