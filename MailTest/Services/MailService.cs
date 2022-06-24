using MailTest.Models.Contex;
using MailTest.Models.Models;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Hosting;
using MailKit.Net.Smtp;
using System.Threading;

namespace MailTest.Services
{
    public interface IMailService
    {
        public bool SendMailToAll(Models.Models.MailMessage mailMessage);


    }

    public class MailService : IMailService
    {
        MailContext db = new MailContext();

        //private readonly IEmailConfiguration _emailConfiguration;
        //private readonly IWebHostEnvironment _webHostEnvironment;

        public MailService()
        {
        }

        //public MailService(IEmailConfiguration emailConfiguration, IWebHostEnvironment webHostEnvironment)
        //{
        //    _emailConfiguration = emailConfiguration;
        //    _webHostEnvironment = webHostEnvironment;
        //}

        public bool SendMailToAll(Models.Models.MailMessage mailMessage)
        {

            var users = db.Mails.ToList().OrderByDescending(p => p.Id).Where(c => c.Status == false);
            var text = db.MailMessage.SingleOrDefault();
            mailMessage.MessageText = text.MessageText;
            mailMessage.MessageSubject = text.MessageSubject;
            if (users.Count() > 0 && mailMessage.MessageText != null && mailMessage.MessageSubject != null)
            {

                var emailClient = new MailKit.Net.Smtp.SmtpClient();
                emailClient.Connect("smtp.yandex.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate("Mail Buraya", "Şifre Buraya");


                foreach (var item in users)
                {
                    int i = 0;
                    i++;
                    //item.Email = "egeumuttali@hotmail.com";   //test yapmak istersen

                    try
                    {


                        var message = new MimeMessage();
                        message.To.Add(new MailboxAddress(item.Email, item.Email));
                        message.From.Add(new MailboxAddress("Oğulcan KARAKAŞ", "Mail buraya"));
                        message.Subject = mailMessage.MessageSubject;
                        message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                        {
                            Text = mailMessage.MessageText
                        };


                        //using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
                        //{
                        Thread.Sleep(3000);
                            //emailClient.Connect("smtp-mail.outlook.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                            //emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                            //emailClient.Authenticate("ogulcan877@hotmail.com", "*****");
                        emailClient.Send(message);
                        //emailClient.Disconnect(true);
                        

                        item.Status = true;
                        db.SaveChanges();
                        //}
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw e;
                    }

                }
                emailClient.Disconnect(true);



                return true;
            }


            return false;
        }
    }
}
