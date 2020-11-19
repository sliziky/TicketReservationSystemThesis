using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.ShowCQRS.Commands
{
  public class DeleteShowCommand : IRequest<MovieShow>
  {
    public int Id { get; set; }
  }
}
