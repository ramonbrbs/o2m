using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class TokenLogin
    {
        [Key]
        public int CodTokenLogin { get; set; }

        public string Token { get; set; }
        public Parceiro Parceiro { get; set; }
        public int CodParceiro { get; set; }
    }
}
