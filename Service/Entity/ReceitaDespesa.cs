using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ReceitaDespesa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Tipo { get; set; }

        public bool? Ativo { get; set; }

        public int ContaContabil { get; set; }
    }
}
