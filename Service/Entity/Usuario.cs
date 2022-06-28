using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Usuario
    {
      
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<Papel> Papel { get; set; }
        public IEnumerable<UsuarioPapel> UsuariosPapeis { get; set; }
    }
}
