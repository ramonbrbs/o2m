using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Indicado : Object
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

        [DisplayName("Telefone")]
        public string Telefone1 { get; set; }

        [DisplayName("Telefone 2")]
        public string Telefone2 { get; set; }

        public string Email { get; set; }

        public string Operadora { get; set; }
        
        public decimal ValorLead { get; set; }

        [DisplayName("Qtd. Linhas Móveis")]
        public int? QtdLinhasMoveis { get; set; }

        [DisplayName("Qtd. Linhas Fixas")]
        public int? QtdLinhasFixas { get; set; }

        [DisplayName("Qtd. Banda Larga")]
        public int? QtdBandaLarga { get; set; }

        /// <summary>
        /// Link dedicado + central telefonica
        /// </summary>
        [DisplayName("Qtd. Centrais Telefônica")]
        public int? QtdCentraltelefonica { get; set; }

        [DisplayName("Qtd. Links Dedicados")]
        public int? QtdLinkDedicado { get; set; }

        public Parceiro Parceiro { get; set; }
        public int CodParceiro { get; set; }
        public StatusLead Status { get; set; }

        [DisplayName("Data de Solicitação")]
        public DateTime? DataEnvio { get; set; }

    }
}
