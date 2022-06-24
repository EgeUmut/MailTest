using MailTest.Models.Models;
using MailTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("SendMailtoAll")]
        public IActionResult SendMail(MailMessage mailMessage)
        {
            var result = _mailService.SendMailToAll(mailMessage);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
