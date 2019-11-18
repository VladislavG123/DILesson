﻿using System;
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

        public ServiceController(IEntitySaverService entitySaverService)
        {
            this.entitySaverService = entitySaverService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveEntity(EntityDTO entity)
        {
            //var entitySaver = new EntitySaverService();
            await entitySaverService.SaveEntity(entity);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailMessageDTO emailMessage)
        {
            var emailSender = new EmailSenderService();

            await emailSender.SendAsync(emailMessage);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCodeVerefication()
        {
            var smsSender = new SmsSenderService();

            await smsSender.SendAsync("87073035370");

            return Ok();
        }
        // /api/Service/GetCodeVerefication

        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> GetCodeVerefication(string phoneNumber)
        {
            var smsSender = new SmsSenderService();

            await smsSender.SendAsync(phoneNumber);
         
            return Ok();
        }
    }
}