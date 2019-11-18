using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace DILesson.Services
{
    public class SmsSenderService
    {

        public Task SendAsync(string phoneNumber)
        {
            const string accountSid = "ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            const string authToken = "your_auth_token";

            TwilioClient.Init(accountSid, authToken);

            return MessageResource.CreateAsync(
                body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
                from: new Twilio.Types.PhoneNumber("+15017122661"),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );
        }

    }
}
