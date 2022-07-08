using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Model
{
    public class UsuarioViewModel
    {

       
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<PapelViewModel> Papel { get; set; }
        public List<EmpresaEstabelecimentoViewModel> Empresas { get; set; }
       // public List<UsuarioPapelViewModel> PapelUsuario { get; set; }
    }
}
