using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.SeatReservationCQRS.Commands
{
  public class AddSeatToSeatReservationCommand : IRequest<SeatReservation>
  {
    public int Id { get; set; }
    public Seat Seat { get; set; }
  }
}
