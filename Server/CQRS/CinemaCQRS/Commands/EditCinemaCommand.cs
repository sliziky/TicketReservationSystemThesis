using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.CinemaCQRS.Commands
{
  public class EditCinemaCommand : IRequest<Cinema> {
    public Cinema Cinema { get; set; }
    public int Id { get; set; }
  }
}
