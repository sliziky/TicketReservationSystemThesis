using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Models;

namespace TicketReservationSystem.Server.Services
{
   public class MailService : IMailService
   {

      public async Task SendEmailAsync(MailRequest mailRequest)
      {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse("peterbolfa4@gmail.com");
        email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        email.Subject = mailRequest.Subject;
        var builder = new BodyBuilder();
        builder.HtmlBody = mailRequest.Body;
        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("peterbolfa4@gmail.com", "whatthefuc1");
        await smtp.SendAsync(email);
        smtp.Disconnect(true);
      }
    }
}
