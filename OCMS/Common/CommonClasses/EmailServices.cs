using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace OCMS.Common.CommonClasses
{
    public class EmailServices
    {
        public int SendEmail(string to, string body, string subject)
        {
            try
            {

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("muhammadashob96@gmail.com");
                mail.To.Add(to);
                mail.Body = body;
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("muhammadashob96@gmail.com", "mrih kjqz yjof vavf");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return 1;
            }
            catch (Exception) 
            {
                return 0;
            }
        }
    }
}