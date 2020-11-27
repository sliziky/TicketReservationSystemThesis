using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using TicketReservationSystem.Client.Data.NewFolder;
using TicketReservationSystem.Client.Services.Abstraction;

namespace TicketReservationSystem.Client.Services
{
  public class MailService : IMailService
  {

    public async Task SendEmailAsync(string ToEmail, string Subject, string HTMLBody)
    {
      var email = new MimeMessage();
      email.From.Add(MailboxAddress.Parse("peterbolfa4@gmail.com"));
      email.To.Add(MailboxAddress.Parse("peterbolfa4@gmail.com"));
      email.Subject = "Test Email Subject";
      email.Body = new TextPart(TextFormat.Html) { Text = "<h1>Example HTML Message Body</h1>" };

      // send email
      using var smtp = new SmtpClient();
      smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
      smtp.Authenticate("peterbolfa4@gmail.com", "whatthefuc1");
      smtp.Send(email);
      smtp.Disconnect(true);
    }
  }
}

