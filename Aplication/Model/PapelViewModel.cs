using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aplication.Model
{
     public class PapelViewModel
    {
        public int Id { get; set; }
        public string Descricao{ get; set; }
        //[JsonIgnore]
        public List<UsuarioViewModel> Usuario { get; set; }
      //  public List<UsuarioPapelViewModel> PapelUsuario { get; set; }
    }
}
