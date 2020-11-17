using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Context;
using TicketReservationSystem.Server.Data.Repository;
using TicketReservationSystem.Server.Models;
using TicketReservationSystem.Server.Models.DTO;

namespace TicketReservationSystem.Server.CQRS.Queries
{
  public class GetMoviesQuery : IRequest<IEnumerable<MovieDTO>> { }
  public class GetMovieQuery : IRequest<MovieDTO> { public int Id { get; set; }}
}
