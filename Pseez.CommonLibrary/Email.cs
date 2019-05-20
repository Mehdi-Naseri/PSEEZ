using System.Net;
using System.Net.Mail;

namespace Pseez.CommonLibrary
{
    /// <summary>
    ///     کلاس کار با ایمیل
    /// </summary>
    public class Email
    {
        /// <summary>
        ///     آدرس هاست ایمیل
        /// </summary>
        private const string Host = "webmail.pseez.ir";

        /// <summary>
        ///     نام کاربر ایمیل
        /// </summary>
        private const string EmailServerUserName = "itdevelopment@pseez.ir";

        /// <summary>
        ///     رمزعبور ایمیل
        /// </summary>
        private const string EmailServerUserPass = "password@pseez.ir";

        /// <summary>
        ///     ارسال ایمیل
        /// </summary>
        /// <param name="fromMail">از ایمیل</param>
        /// <param name="fromName">نام ارسال کننده</param>
        /// <param name="toMail">به ایمیل</param>
        /// <param name="toName">نام دریافت کننده</param>
        /// <param name="subject">عنوان</param>
        /// <param name="body">توضیحات</param>
        public void SendMail(string fromMail, string fromName, string toMail, string toName, string subject, string body)
        {
            var mail = new MailMessage();
            var smtp = new SmtpClient();
            mail.From = new MailAddress(fromMail, fromName);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true; // This is to enable HTML in your email body
            smtp.Host = Host;
            smtp.Port = 25;
            smtp.Credentials = new NetworkCredential(EmailServerUserName, EmailServerUserPass);
            mail.To.Add(new MailAddress(toMail, toName));
            smtp.Send(mail);
        }

        public void SendMailWithYahoo()
        {
            var smtpAddress = "smtp.mail.yahoo.com";
            var portNumber = 587;
            var enableSSL = true;

            var emailFrom = "mehdi_55555@yahoo.com";
            var password = "password";
            var emailTo = "someone@domain.com";
            var subject = "mehdi_55555@yahoo.com";
            var body = "Hello, I'm just writing this to say Hi! Goodmorning Mehdi!";

            using (var mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                // Can set to false, if you are sending pure text.

                using (var smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
    }
}