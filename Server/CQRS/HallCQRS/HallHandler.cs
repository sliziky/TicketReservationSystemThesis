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
    IRequestHandler<GetHallsQuery, IEnumerable<Hall>>
  {
    private IMapper _mapper;
    private HallRepository _repository;
    private SeatRepository _seatRepository;

    public HallHandler(IMapper mapper, HallRepository repository, SeatRepository seatRepository)
    {
      _mapper = mapper;
      _repository = repository;
      _seatRepository = seatRepository;
    }
    public async Task<Hall> Handle(AddHallCommand request, CancellationToken cancellationToken)
    {
      //foreach (var seat in request.Hall.Seats) {
      //  await _seatRepository.SaveAsync(seat);
      //}
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
  }
}
