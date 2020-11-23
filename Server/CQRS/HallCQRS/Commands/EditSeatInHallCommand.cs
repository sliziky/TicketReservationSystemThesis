using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.HallCQRS.Commands
{
  public class EditSeatInHallCommand : IRequest<Seat>
  {
    public int SeatId { get; set; }
    public Seat Seat { get; set; }
  }
}
