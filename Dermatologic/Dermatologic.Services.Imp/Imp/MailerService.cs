using System;
using System.Configuration;
using System.Net.Mail;
using Dermatologic.Domain.Contracts;

namespace Dermatologic.Services
{
    public class MailerService : IMailerService
    {
        public MailResponse SendEmail(MailRequest mailRequest)
        {
            var response = new MailResponse();
            try
            {
                var mailSender = ConfigurationManager.AppSettings["mail"];
                var smtp = new SmtpClient();
                var mail = new MailMessage { From = new MailAddress(mailSender) };
                foreach(var item in mailRequest.To)
                    mail.To.Add(item);
                mail.Subject = mailRequest.Subject;
                mail.Body = mailRequest.Body;
                mail.IsBodyHtml = mailRequest.IsHtmlBody;
                smtp.Host = mailRequest.Host;
                smtp.Port = mailRequest.Port;
                smtp.EnableSsl = mailRequest.EnableSSL;
                smtp.Credentials = new System.Net.NetworkCredential(mailSender, "P@$$w0rd_devsoftx");
                smtp.Send(mail);
                response.OperationResult = OperationResult.Success;
                return response;
            }
            catch (Exception ex)
            {
                response.OperationResult = OperationResult.Failed;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}