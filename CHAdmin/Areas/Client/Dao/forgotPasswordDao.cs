using Model.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace CHAdmin.Areas.Client.Dao
{
    public class forgotPasswordDao
    {
        
        public void sendMail(string email, string code)
        {
            var EmailGui = ConfigurationManager.AppSettings["EmailGui"].ToString();
            var EmailGuiTenHienThi = ConfigurationManager.AppSettings["EmailGuiTenhienthi"].ToString();
            var EmailMatkhau = ConfigurationManager.AppSettings["EmailMatkhau"].ToString();
            var SMTHost = ConfigurationManager.AppSettings["SMTHost"].ToString();
            var SMTPort = int.Parse(ConfigurationManager.AppSettings["SMTPort"].ToString());
            bool SSL = bool.Parse(ConfigurationManager.AppSettings["SSL"].ToString());
            string subject = "Khôi phục mật khẩu";
            string body = "Xin chào " + email + ", đây là email được gửi từ Admin để khôi phục mật khẩu cho bạn " +
                "\nXin hãy nhấn vào link dưới để tiến hành khôi phục mật khẩu\n" +
                "<a href=" + $"'https://localhost:44392/Client/ForgotPassword/Khoiphucmatkhau?code={code}&email={email}'" + ">Click vào đây</a>";
            MailMessage mailMessage = new
                MailMessage(new MailAddress(EmailGui, EmailGuiTenHienThi), new MailAddress(email));
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential(EmailGui, EmailMatkhau);
            client.Host = SMTHost;
            client.Port = SMTPort;
            client.EnableSsl = SSL;
            client.Send(mailMessage);
        }

    }
}