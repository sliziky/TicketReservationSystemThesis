using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.HallCQRS.Commands;
using TicketReservationSystem.Server.CQRS.HallCQRS.Queries;
using TicketReservationSystem.Server.Data.Repository;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.HallCQRS
{
  public class HallHandler :
    IRequestHandler<AddHallCommand, Hall>,
    IRequestHandler<GetHallQuery, Hall>,
    IRequestHandler<GetHallsQuery, IEnumerable<Hall>>,
    IRequestHandler<AddSeatToHallCommand, Seat>,
    IRequestHandler<DeleteHallCommand, Hall>,
    IRequestHandler<DeleteHallsCommand, IEnumerable<Hall>>,
    IRequestHandler<AddMovieShowToHallCommand, MovieShow>
  {
    private IMapper _mapper;
    private HallRepository _repository;
    private SeatRepository _seatRepository;
    private ShowRepository _showRepository;

    public HallHandler(IMapper mapper, HallRepository repository, SeatRepository seatRepository, ShowRepository showRepository)
    {
      _mapper = mapper;
      _repository = repository;
      _seatRepository = seatRepository;
      _showRepository = showRepository;
    }
    public async Task<Hall> Handle(AddHallCommand request, CancellationToken cancellationToken)
    {
      return await _repository.SaveAsync(request.Hall);
    }

    public async Task<IEnumerable<Hall>> Handle(GetHallsQuery request, CancellationToken cancellationToken)
    {
      return await _repository.GetAllAsync();
    }

    public async Task<Hall> Handle(GetHallQuery request, CancellationToken cancellationToken)
    {
      return await _repository.GetAsync(request.Id);
    }

    public async Task<Seat> Handle(AddSeatToHallCommand request, CancellationToken cancellationToken)
    {
      return await _repository.AddSeat(request.Id, request.Seat);
    }

    public async Task<Hall> Handle(DeleteHallCommand request, CancellationToken cancellationToken)
    {
      return await _repository.DeleteAsync(request.Id);
    }

    public async Task<IEnumerable<Hall>> Handle(DeleteHallsCommand request, CancellationToken cancellationToken)
    {
      return await _repository.DeleteAllAsync();
    }

    public async Task<MovieShow> Handle(AddMovieShowToHallCommand request, CancellationToken cancellationToken)
    {
      return await _showRepository.AddMovieShow(request.Id, request.MovieId, request.Show);
    }
  }
}
