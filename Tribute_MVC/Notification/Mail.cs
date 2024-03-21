using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Tribute_MVC.Notification
{
    public class Mail
    {
        public static bool SendMailToUser(string toAddress,string title, string msg)
        {
            try
            {
                string MessageBody = msg;
                string Password = "snhidnogvbmytasm";
                string FromAddress = "manger.lms@gmail.com";
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(FromAddress);
                message.To.Add(new MailAddress(toAddress));
                message.Subject = title;
                message.Body = MessageBody;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(FromAddress, Password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
