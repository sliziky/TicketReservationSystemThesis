using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.ReservationsCQRS.Queries
{
  public class GetReservationQuery : IRequest<Reservation>
  {
    public int Id { get; set; }
  }
}
