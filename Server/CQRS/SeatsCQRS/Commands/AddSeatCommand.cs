using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.SeatsCQRS.Commands
{
  public class AddSeatCommand : IRequest<Seat>
  {
    public Seat Seat { get; set; }
  }
}
