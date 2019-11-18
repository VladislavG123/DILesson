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
            using (SmtpClient client = new SmtpClient("smpt.mail.ru", 457))
            {
                // еще что-то
                return client.SendMailAsync("admin@mail.ru", emailMessage.To, emailMessage.Title, emailMessage.Text);
            }
        }
    }
}
