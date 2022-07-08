using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entity
{
     public class Papel
    {

        
        public int Id { get; set; }
        public string Descricao { get; set; }
    
        public List<Usuario> Usuario { get; set; }
        public IEnumerable<UsuarioPapel> PapelUsuario { get; set; }
    }
}
