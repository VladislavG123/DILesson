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
            const string accountSid = "ACa902f79f4063bfa4e4da8b2930f931b2";
            const string authToken = "55ce5d687fbdf981f550141835655fbf";

            TwilioClient.Init(accountSid, authToken);

            return MessageResource.CreateAsync(
                body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
                from: new Twilio.Types.PhoneNumber("+12056198687"),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );
        }

    }
}
