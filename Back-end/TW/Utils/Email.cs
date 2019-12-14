using System;
using System.Net;
using System.Net.Mail;
using Spire.Pdf;

namespace TW.Utils {
    public class Email {
        public bool EnvioEmailComprador (string email, string titulo, string body, PdfDocument anexo) {
            try {
                MailMessage _mailMessage = new MailMessage ();
                _mailMessage.From = new MailAddress ("lightcodexp@gmail.com");
                _mailMessage.CC.Add (email);
                _mailMessage.Subject = titulo;
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = body;
                _mailMessage.Attachments.Add (new Attachment (anexo.ToString ()));
                SmtpClient _smtpClient = new SmtpClient ("smtp.gmail.com", Convert.ToInt32 ("587"));
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential ("lightcodexp@gmail.com", "Codexp@l23");
                _smtpClient.EnableSsl = true;
                _smtpClient.Send (_mailMessage);
                return true;
            } catch (Exception e) {
                throw e;
            }
        }
        public bool EnvioEmail (string email, string titulo, string body) {
            try {
                MailMessage _mailMessage = new MailMessage ();
                _mailMessage.From = new MailAddress ("lightcodexp@gmail.com");
                _mailMessage.CC.Add (email);
                _mailMessage.Subject = titulo;
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = body;
                SmtpClient _smtpClient = new SmtpClient ("smtp.gmail.com", Convert.ToInt32 ("587"));
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential ("lightcodexp@gmail.com", "Codexp@l23");
                _smtpClient.EnableSsl = true;
                _smtpClient.Send (_mailMessage);
                return true;
            } catch (Exception e) {
                throw e;
            }
        }
    }
}