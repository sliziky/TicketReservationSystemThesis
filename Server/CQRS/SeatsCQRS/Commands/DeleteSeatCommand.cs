using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.SeatsCQRS.Commands
{
  public class DeleteSeatCommand : IRequest<Seat>
  {
    public int Id { get; set; }
  }
}
