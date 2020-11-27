using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.ReservationsCQRS.Commands
{
  public class AddPaymentToReservationCommand : IRequest<Reservation>
  {
    public int Id { get; set; }
    public Payment Payment { get; set; }
  }
}
