using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.HallCQRS.Queries
{
  public class GetHallsQuery : IRequest<IEnumerable<Hall>>
  {
  }
}
