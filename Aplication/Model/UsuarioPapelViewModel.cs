using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Model
{
     public class UsuarioPapelViewModel
    {
        public UsuarioViewModel Usuario { get; set; }
        public int IdUsuario { get; set; }
        public PapelViewModel Papel { get; set; }
        public int IdPapel { get; set; }
    }
}
