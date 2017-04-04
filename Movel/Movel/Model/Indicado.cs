using System;

namespace Movel.Model
{
    public class Indicado : Object
    {
        public enum StatusLead
        {
            Pendente = 0,
            Executado = 1,
            Negado = 2
        }

        
        public int CodIndicado { get; set; }

        
        public string Nome { get; set; }

        
        public string Contato { get; set; }

        
        public string Telefone1 { get; set; }

        
        public string Telefone2 { get; set; }

        public string Email { get; set; }

        public string Operadora { get; set; }
        
        public decimal ValorLead { get; set; }

        
        public int? QtdLinhasMoveis { get; set; }

        
        public int? QtdLinhasFixas { get; set; }

        
        public int? QtdBandaLarga { get; set; }

        /// <summary>
        /// Link dedicado + central telefonica
        /// </summary>
        
        public int? QtdCentraltelefonica { get; set; }

        
        public int? QtdLinkDedicado { get; set; }

        public Parceiro Parceiro { get; set; }
        public int CodParceiro { get; set; }
        public StatusLead Status { get; set; }

        
        public DateTime? DataEnvio { get; set; }

    }
}
