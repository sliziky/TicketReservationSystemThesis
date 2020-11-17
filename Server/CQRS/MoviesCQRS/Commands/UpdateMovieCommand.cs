using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Models;

namespace TicketReservationSystem.Server.CQRS.Commands
{
  public class UpdateMovieCommand : IRequest<Movie> {
    public Movie Movie { get; set; }
    public int Id { get; set; }
  }
}
