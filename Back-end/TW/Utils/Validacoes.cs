using System;
using System.Net;
using System.Net.Mail;
using Spire.Pdf;

namespace TW.Utils
{
    public class Validacoes
    {
        public bool EnvioEmail (string email, string titulo, string body, PdfDocument anexo) {
            try {
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage ();
                // Remetente
                _mailMessage.From = new MailAddress ("lightcodexp@gmail.com");

                // Destinatario seta no metodo abaixo

                //Contrói o MailMessage
                _mailMessage.CC.Add (email);
                _mailMessage.Subject = titulo;
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = body;
                _mailMessage.Attachments.Add(new Attachment(anexo.ToString()));
                

                //CONFIGURAÇÃO COM PORTA
                SmtpClient _smtpClient = new SmtpClient ("smtp.gmail.com", Convert.ToInt32 ("587"));

                //CONFIGURAÇÃO SEM PORTA

                // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

                // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação);

                _smtpClient.UseDefaultCredentials = false;

                _smtpClient.Credentials = new NetworkCredential ("lightcodexp@gmail.com", "Codexp@l23"   );

                _smtpClient.EnableSsl = true;

                _smtpClient.Send (_mailMessage);

                return true;

            } catch (Exception ex) {
                throw ex;
            }
        }

        public bool EnvioEmailUsers (string email, string titulo, string body) {
            try {
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage ();
                // Remetente
                _mailMessage.From = new MailAddress ("lightcodexp@gmail.com");

                // Destinatario seta no metodo abaixo

                //Contrói o MailMessage
                _mailMessage.CC.Add (email);
                _mailMessage.Subject = titulo;
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = body;                

                //CONFIGURAÇÃO COM PORTA
                SmtpClient _smtpClient = new SmtpClient ("smtp.gmail.com", Convert.ToInt32 ("587"));

                _smtpClient.UseDefaultCredentials = false;

                _smtpClient.Credentials = new NetworkCredential ("lightcodexp@gmail.com", "Codexp@l23");

                _smtpClient.EnableSsl = true;

                _smtpClient.Send (_mailMessage);

                return true;

            } catch (Exception ex) {
                throw ex;
            }
        }

    }
}