using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovcontabilClone.Entity
{
    public class ContaCorrente
    {
        public int Id { get; set; }
        [ForeignKey("BancoId")]
        public int BancoId { get; set; }
        public Banco Banco { get; set; }

        public string Agencia { get; set; }

        public string Conta { get; set; }

        public int ContaContabil { get; set; }

        public bool? Aplicacao { get; set; }
    }
}
