using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Models;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.Services
{
  public interface IMailService
  {
    Task SendEmailAsync(MailRequest mailRequest, int id);
  }
}
