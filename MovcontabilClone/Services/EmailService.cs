using Aplication.Model;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MailKit.Net.Smtp;

namespace MovcontabilClone.Services
{
    public class EmailService : IEmailService
    {

        private readonly EmailSettings _emailSettings;
        public EmailService( IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task SendEmmailAsync(string emailDestinatario, string assunto, string mensagemTexto, string mensagemHtml)
        {
            var mensagem = new MimeMessage();
            mensagem.From.Add(new MailboxAddress( _emailSettings.NomeRemetente, _emailSettings.EmailRemetente));
            mensagem.To.Add(MailboxAddress.Parse(emailDestinatario));
            mensagem.Subject = assunto;
            var builder = new BodyBuilder {TextBody = mensagemTexto, HtmlBody = mensagemHtml };
            mensagem.Body = builder.ToMessageBody();

            try
            {
                var smtp = new SmtpClient();
                smtp.ServerCertificateValidationCallback = (s,c,h,e) => true;
                await smtp.ConnectAsync(_emailSettings.EnderecoServidor, _emailSettings.PortaServidor).ConfigureAwait(false);
                await smtp.AuthenticateAsync(_emailSettings.EmailRemetente, _emailSettings.Senha).ConfigureAwait(false);
                await smtp.SendAsync(mensagem).ConfigureAwait(false);
                await smtp.DisconnectAsync(true).ConfigureAwait(false);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
