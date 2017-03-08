using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Indicado
    {
        public enum StatusLead
        {
            Pendente = 0,
            Executado = 1,
            Negado = 2
        }

        [Key]
        public int CodIndicado { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        public string Contato { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }
        public string Operadora { get; set; }
        
        public decimal ValorLead { get; set; }


        public int QtdLinhasMoveis { get; set; }
        public int QtdLinhasFixas { get; set; }
        public int QtdBandaLarga { get; set; }
        /// <summary>
        /// Link dedicado + central telefonica
        /// </summary>
        public int QtdCentraltelefonica { get; set; }

        public int QtdLinkDedicado { get; set; }

        public Parceiro Parceiro { get; set; }
        public int CodParceiro { get; set; }
        public StatusLead Status { get; set; }

    }
}
