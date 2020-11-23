using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.CinemaCQRS.Commands
{
  public class DeleteCinemaCommand : IRequest<Cinema>
  {
    public int Id { get; set; }
  }
}
