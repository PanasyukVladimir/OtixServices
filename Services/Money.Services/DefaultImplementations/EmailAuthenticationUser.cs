using MailKit.Net.Smtp;
using MimeKit;
using Money.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Services.DefaultImplementations
{
    public class EmailAuthenticationUser : IAuthenticationUser
    {
        public async Task SendMessageAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "otix6667866@ukr.net"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                //await client.ConnectAsync("smtp.gmail.com", 587, true);
                //await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.ConnectAsync("smtp.ukr.net", 465, true);
                await client.AuthenticateAsync("otix6667866@ukr.net", "Tv1LNT1Ez0UJgq53");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
