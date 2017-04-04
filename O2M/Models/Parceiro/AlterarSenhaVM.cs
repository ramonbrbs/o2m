using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace O2M.Models.Parceiro
{
    public class AlterarSenhaVM
    {
        [DisplayName("Senha Antiga")]
        public string SenhaAntiga { get; set; }

        [DisplayName("Senha Nova")]
        public string SenhaNova { get; set; }

        [DisplayName("Repetir Senha Nova")]
        public string SenhaNova2 { get; set; }
    }
}