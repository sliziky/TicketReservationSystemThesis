using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Context;
using TicketReservationSystem.Server.Models;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.Services
{
   public class MailService : IMailService
   {

        private MyContext _context;

        public MailService(MyContext context)
        {
            _context = context;
        }

        public async Task SendEmailAsync(MailRequest mailRequest, int reservationId)
       {
        var cinema = _context.Cinemas.Include(h => h.Account).ToList().FirstOrDefault(c => !c.IsObsolete);
        var reservation = _context.Reservations.Include(h => h.Payment).Include(h => h.MovieShow).Include(h => h.ReservationSeats).ThenInclude(h => h.Seats).FirstOrDefault(r => r.ReservationId == reservationId);
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(cinema.Account.Email);
        email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        email.Subject = mailRequest.Subject;
        var builder = new BodyBuilder();
        builder.HtmlBody = "Price: " + (reservation.Payment.TotalPrice/100).ToString() +'\n'+
                "For " + reservation.MovieShow.Movie.Title;
        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
         smtp.Authenticate(cinema.Account.Email, "KillMe111");
        await smtp.SendAsync(email);
        smtp.Disconnect(true);
      }
    }
}
