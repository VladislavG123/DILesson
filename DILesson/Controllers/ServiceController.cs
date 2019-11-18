using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DILesson.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mail;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using DILesson.Services;

namespace DILesson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> SaveEntity(EntityDTO entity)
        {
            var entitySaver = new EntitySaverService();
            await entitySaver.SaveEntity(entity);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailMessageDTO emailMessage)
        {
            var emailSender = new EmailSenderService();

            await emailSender.SendAsync(emailMessage);

            return Ok();
        }


        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> GetCodeVerefication(string phoneNumber)
        {
            var smsSender = new SmsSenderService();

            await smsSender.SendAsync(phoneNumber);
            return Ok();
        }
    }
}