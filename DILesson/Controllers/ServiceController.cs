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


// DependencyInjections внедрение зависимостей

namespace DILesson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IEntitySaverService entitySaverService;
        private readonly SmsSenderService smsSenderService;
        private readonly EmailSenderService emailSenderService;

        public ServiceController(IEntitySaverService entitySaverService, SmsSenderService smsSenderService, EmailSenderService emailSenderService)
        {
            this.entitySaverService = entitySaverService;
            this.smsSenderService = smsSenderService;
            this.emailSenderService = emailSenderService;
        }

        [HttpPut]
        public async Task<IActionResult> SaveEntity(EntityDTO entity)
        {
            //var entitySaver = new EntitySaverService();
            await entitySaverService.SaveEntity(entity);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailMessageDTO emailMessage)
        {
            await emailSenderService.SendAsync(emailMessage);

            return Ok();
        }

       
        // /api/Service/GetCodeVerefication

        [HttpGet/*("{phoneNumber}")*/]
        public async Task<IActionResult> GetCodeVerefication(string phoneNumber)
        {
            await smsSenderService.SendAsync(phoneNumber);
         
            return Ok();
        }
    }
}