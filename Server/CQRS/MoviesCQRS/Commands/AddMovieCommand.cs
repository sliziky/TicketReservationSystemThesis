using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Data.Repository;
using TicketReservationSystem.Server.Models;
using TicketReservationSystem.Server.Models.DTO;

namespace TicketReservationSystem.Server.CQRS.Commands
{
  public class AddMovieCommand : IRequest<Movie> { public Movie Movie { get; set; } }
}
