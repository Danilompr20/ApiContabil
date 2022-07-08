using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
     public class UsuarioPapel
    {
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public Papel Papel { get; set; }
        public int PapelId { get; set; }
    }
}
