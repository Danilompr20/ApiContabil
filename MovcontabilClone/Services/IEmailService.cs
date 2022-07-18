using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovcontabilClone.Services
{
     public interface IEmailService
    {
        Task SendEmmailAsync(string emailDestinatario, string assunto, string mensagemTexto, string mensagemHtml);
        
    }
}
