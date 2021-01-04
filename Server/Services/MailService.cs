using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MimeKit;
using QRCoder;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        private IConfiguration _config;
        public MailService(MyContext context, IConfiguration config)
        {
            _config = config;
            _context = context;
        }

        public async Task SendEmailAsync(MailRequest mailRequest, int reservationId)
       {
            var cinema = _context.Cinemas.ToList().FirstOrDefault(c => !c.IsObsolete);
            var reservation = _context.Reservations.Include(h => h.Payment).Include(h => h.MovieShow).ThenInclude(ms => ms.Movie).Include(h => h.MovieShow).ThenInclude(s => s.Hall).ThenInclude(s => s.Cinema).Include(h => h.ReservationSeats).ThenInclude(h => h.Seats).FirstOrDefault(r => r.ReservationId == reservationId);

            var apiKey = cinema.SendGridApiKey;
            var client = new SendGridClient(apiKey);

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode($"Show : {reservation.MovieShow.Hall.Cinema.Name} {reservation.MovieShow.Hall.Name} {reservation.MovieShow.Movie.Title} {reservation.MovieShow.Date}\n" +
                $"Number of tickets {reservation.ReservationSeats[0].Seats.Count}\n" +
                $"Reservation: {reservation.ReservationId}", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            ImageConverter converter = new ImageConverter();
            var bytes = (byte[])converter.ConvertTo(qrCodeImage, typeof(byte[]));
            var file = Convert.ToBase64String(bytes);


            var from = new EmailAddress(_config.GetConnectionString("Email"), "Tickets " + reservation.MovieShow.Movie.Title);
            var to = new EmailAddress(reservation.EmailForTickets);
            var plainTextContent = " ";
            var htmlContent = "Tickets for you";

            var msg = MailHelper.CreateSingleEmail(from, to, "Tickets", plainTextContent, htmlContent);
            msg.AddAttachment("Tickets.png", file);
            await client.SendEmailAsync(msg);
        }
    }
}
