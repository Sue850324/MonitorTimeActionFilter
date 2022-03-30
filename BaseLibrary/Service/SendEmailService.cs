using System.Net;
using System.Net.Mail;
using System;
using System.Web.Configuration;
using BaseLibrary.Base;
using static MonitorTimeActionFilterAttribute.Service.GetAlertFactory;

namespace MonitorTimeActionFilterAttribute.Service
{
    public class SendEmailService : BaseAlertService
    {
        protected override bool DoSend(string subject, string context)
        {
            string emailFrom = WebConfigurationManager.AppSettings["AlertEmail"];
            string host = WebConfigurationManager.AppSettings["Host"];
            string port = WebConfigurationManager.AppSettings["Port"];
            string password = WebConfigurationManager.AppSettings["Password"];
            int portNumber = Convert.ToInt32(port);

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add("sue850324@gmail.com");
                mail.Subject = subject;
                mail.Body = context;
                mail.IsBodyHtml = false;

                try
                {
                    using (SmtpClient smtp = new SmtpClient(host, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }

                    Send(PublishTypes.Line, subject, context);

                    return true;
                }
                catch
                {
                    return false;
                }
            }       
        }
    }
}