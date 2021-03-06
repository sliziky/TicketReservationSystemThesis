using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.CinemaCQRS.Queries
{
  public class GetCinemaQuery : IRequest<Cinema>
  {
    public int Id { get; set; }
  }
}
