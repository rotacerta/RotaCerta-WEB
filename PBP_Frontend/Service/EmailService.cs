using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;

namespace PBP_Frontend.Service
{
    public class EmailService
    {
        private string email = "replyeras@gmail.com";
        private string password = "grupoeras06";
        private string title = "Olá, aqui é a equipe de segurança ERAS";
        private string content 
            = "Foi solicitada a alteração da senha do seu" +
            "e-mail no aplicativo RotaCerta, você confirma essa ação?";

        public bool Send(string sendToName, string sendToEmail)
        {
            MailMessage mailMessage = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();

            try
            {

                mailMessage.From = new MailAddress(email, "Display name");
                mailMessage.To.Add(new MailAddress(sendToEmail, sendToName));

                mailMessage.Subject = title;
                mailMessage.Body = content;


                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential(email, password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}