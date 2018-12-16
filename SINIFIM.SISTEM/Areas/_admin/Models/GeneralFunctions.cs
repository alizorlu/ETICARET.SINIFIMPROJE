using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace SINIFIM.SISTEM.Areas._admin.Models
{
    public class GeneralFunctions
    {
        public async Task<bool>
            SendEmail(string email,string content)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("srvm02.turhost.com");

                mail.From = new MailAddress("sinifim@azorlua.com");
                //mail.AlternateViews = new AlternateViewCollection();
                mail.To.Add(email);
                mail.Subject = "Sınıfım.Com - Şifre Sıfırlama İşlem";
                mail.IsBodyHtml = true;
                string mailContent = @"<html>
<body>
<p>Merhaba <strong>{0} tarihinde şifreniz sıfırlanmıştır</strong></p>
Aşağıdaki yeni şifreniz mevcuttur.<br>{1}
</html>";
                mail.Body = mailContent.Replace("{0}", DateTime.Now.ToLongDateString());

                mail.Body = mailContent.Replace("{1}", content);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("sinifim@azorlua.com", "123123123Ali.");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        
    }
}