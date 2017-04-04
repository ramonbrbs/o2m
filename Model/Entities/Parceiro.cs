using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        public string Documento { get; set; }

        public string Agencia { get; set; }
        public Banco Banco { get; set; }

        [Required(ErrorMessage = "O campo banco é obrigatório")]
        [DisplayName("Banco")]
        public int? CodBanco { get; set; }
        public string Conta { get; set; }
        public string Token { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public List<Indicado> Indicados { get; set; }

        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set { _senha = Crypto.ConvertSHA1(value); }
        }




    }
}
