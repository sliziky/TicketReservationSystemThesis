using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.ReservationsCQRS.Commands
{
  public class DeleteReservationCommand : IRequest<Reservation>
  {
    public int Id { get; set; }
  }
}
