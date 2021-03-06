using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.HallCQRS.Commands
{
  public class AddHallCommand : IRequest<Hall> { public Hall Hall { get; set; } }
}
