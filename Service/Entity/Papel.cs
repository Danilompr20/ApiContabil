using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
     public class Papel
    {

        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<Usuario> Usuario { get; set; }
        public IEnumerable<UsuarioPapel> UsuariosPapeis { get; set; }
    }
}
