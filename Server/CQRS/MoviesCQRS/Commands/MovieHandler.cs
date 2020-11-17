using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.Queries;
using TicketReservationSystem.Server.Data.Repository;
using TicketReservationSystem.Server.Models;
using TicketReservationSystem.Server.Models.DTO;
using static TicketReservationSystem.Server.CQRS.Commands.AddMovieCommand;

namespace TicketReservationSystem.Server.CQRS.Commands
{
  public class MovieHandler :
    IRequestHandler<AddMovieCommand, Movie>,
    IRequestHandler<DeleteMovieCommand>,
    IRequestHandler<UpdateMovieCommand, Movie>,
    IRequestHandler<GetMoviesQuery, IEnumerable<MovieDTO>>,
    IRequestHandler<GetMovieQuery, MovieDTO>
    
  {
    private IMapper _mapper;
    private MovieRepository _repository;

    public MovieHandler(MovieRepository repository, IMapper mapper)
    {
      _mapper = mapper;
      _repository = repository;
    }
    public async Task<Movie> Handle(AddMovieCommand request, CancellationToken cancellationToken)
    {
      return await _repository.SaveAsync(request.Movie);
    }

    public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
      await _repository.DeleteAsync(request.Id);
      return Unit.Value;
    }

    public async Task<Movie> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
      var movie = await _repository.UpdateAsync(request.Id, request.Movie);
      return movie;
    }


    public async Task<IEnumerable<MovieDTO>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
      var movies = await _repository.GetAllAsync();
      return movies.Select(movie => _mapper.Map<Movie, MovieDTO>(movie)).ToList();
    }

    public async Task<MovieDTO> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
      var movie = await _repository.GetAsync(request.Id);
      return _mapper.Map<Movie, MovieDTO>(movie);
    }
  }
}
