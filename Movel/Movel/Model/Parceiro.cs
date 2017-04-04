using System;
using System.Collections.Generic;

namespace Movel.Model
{
    public class Parceiro
    {
        
        public int CodParceiro { get; set; }

        
        public string Nome { get; set; }

        
        public string Documento { get; set; }

        public string Agencia { get; set; }
        
        public int? CodBanco { get; set; }
        public string Conta { get; set; }
        public string Token { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        

        public String Senha { get; set; }




    }
}
