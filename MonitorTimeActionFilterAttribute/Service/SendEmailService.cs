using MonitorTimeActionFilterAttribute.Interface;
using System.Net;
using System.Net.Mail;

namespace MonitorTimeActionFilterAttribute.Service
{
    public class SendEmailService :ISendAlert
    {
        public void Send()
        {
            //設定smtp主機
            string smtpAddress = "smtp.gmail.com";
            //設定Port
            int portNumber = 587;
            bool enableSSL = true;
            //填入寄送方email和密碼
            string emailFrom = "testEmail@gmail.com";//虛構
            string password = "test01234";//虛構
            //收信方email 可以用逗號區分多個收件人                
            string emailTo = "test2Email@gmail.com";//虛構
            //主旨
            string subject = "[系統]警告信";
            //內容
            string body = "執行時間超過五秒";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                // 若你的內容是HTML格式，則為True
                mail.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
    }
}