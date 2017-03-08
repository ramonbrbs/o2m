using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Model.Entities
{
    public class Parceiro
    {
        [Key]
        public int CodParceiro { get; set; }

        [Required]
        public string Nome { get; set; }

        [Index("CNPJ_CPF", IsUnique = true)]
        public string Documento { get; set; }

        public string Agencia { get; set; }
        public string Banco { get; set; }

        [Required]
        [EmailAddress]
        [Index("Email_Unique",IsUnique = true)]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set { _senha = Crypto.ConvertSHA1(value); }
        }


    }
}
