using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.SeatReservationCQRS.Commands
{
  public class AddSeatReservationCommand : IRequest<SeatReservation>
  {
    public SeatReservation SeatReservation { get; set; }
  }
}
