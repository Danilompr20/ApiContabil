using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Model
{
    public class UsuarioToken
    {
        public bool  Autenticado { get; set; }
        public DateTime Expirado { get; set; }
        public string Token { get; set; }
        public string Mensagem { get; set; }
    }
}
