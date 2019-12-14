using DILesson.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DILesson.Services
{
    public class EmailSenderService
    {
        public Task SendAsync(EmailMessageDTO emailMessage)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.mail.ru");

            mail.From = new MailAddress("gvo_step2018@mail.ru");
            mail.To.Add(emailMessage.To);
            mail.Subject = emailMessage.Title;
            mail.Body = emailMessage.Text;

            smtpServer.Port = 465;
            smtpServer.Credentials = new System.Net.NetworkCredential("gvo_step2018@mail.ru", "8W8_55Vlad");
            smtpServer.EnableSsl = true;

            smtpServer.SendMailAsync(mail);

            return Task.CompletedTask;
        }
    }
}
