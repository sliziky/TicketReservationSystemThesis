using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.CinemaCQRS.Commands
{
  public class AddHallToCinemaCommand : IRequest<Hall>
  {
    public int Id { get; set; }
    public Hall Hall { get; set; }
  }
}
