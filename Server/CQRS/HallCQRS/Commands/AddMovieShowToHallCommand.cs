using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.HallCQRS.Commands
{
  public class AddMovieShowToHallCommand : IRequest<MovieShow>
  {
    public int Id { get; set; }
    public int MovieId { get; set; }
    public MovieShow Show { get; set; }
  }
}
