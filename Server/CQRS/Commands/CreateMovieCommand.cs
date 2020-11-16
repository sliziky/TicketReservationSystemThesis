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
  public class CreateMovieCommand
  {
    public class Query : IRequest<Movie> { public Movie Movie { get; set; } }
    public class CreateMovieHandler : IRequestHandler<Query, Movie>
    {
      private readonly MovieRepository _repository;
      private readonly IMapper _mapper;

      public CreateMovieHandler(MovieRepository repository, IMapper mapper)
      {
        _mapper = mapper;
        _repository = repository;
      }

      public async Task<Movie> Handle(Query request, CancellationToken cancellationToken)
      {
        return await _repository.SaveAsync(_mapper.Map<Movie, MovieDTO>(request.Movie));
      }
    }
  }
}
