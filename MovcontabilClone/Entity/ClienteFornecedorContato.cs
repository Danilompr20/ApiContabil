using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovcontabilClone.Entity
{
    public class ClienteFornecedorContato
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Departamento { get; set; }

        public string Telefone { get; set; }

        public string TelefoneComercial { get; set; }

        public string Celular { get; set; }
    }
}
