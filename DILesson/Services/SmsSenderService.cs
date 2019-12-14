using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace DILesson.Services
{
    public class SmsSenderService
    {

        public Task SendAsync(string phoneNumber)
        {
            var code = new Random().Next(1000, 9999);

            phoneNumber.TrimStart('+');
            string url = $"https://api.mobizon.kz/service/message/sendsmsmessage?" +
                $"recipient={phoneNumber}&text=Code: {code}" +
                $"&apiKey=kz739b92e1907f9680a0b71e3851ab59dcec2c26af77d8ee39876b18483fa5b232126f";

            using (var webClient = new WebClient())
            {
                webClient.DownloadString(new System.Uri(url));
            }

            return Task.CompletedTask;
        }

    }
}
