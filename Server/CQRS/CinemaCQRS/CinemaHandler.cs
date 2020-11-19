using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.CinemaCQRS.Commands;
using TicketReservationSystem.Server.CQRS.CinemaCQRS.Queries;
using TicketReservationSystem.Server.Data.Repository;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.CinemaCQRS
{
  public class CinemaHandler
    : IRequestHandler<AddCinemaCommand, Cinema>,
      IRequestHandler<EditCinemaCommand, Cinema>,
      IRequestHandler<GetCinemaQuery, Cinema>,
    IRequestHandler<GetCinemasQuery, IEnumerable<Cinema>>,
    IRequestHandler<AddHallToCinemaCommand, Hall>
  {
    private IMapper _mapper;
    private CinemaRepository _repository;

    public CinemaHandler(IMapper mapper, CinemaRepository repository)
    {
      _mapper = mapper;
      _repository = repository;
    }

    public async Task<Cinema> Handle(GetCinemaQuery request, CancellationToken cancellationToken)
    {
      return await _repository.GetAsync(request.Id);
    }

    public async Task<Cinema> Handle(EditCinemaCommand request, CancellationToken cancellationToken)
    {
      return await _repository.UpdateAsync(request.Id, request.Cinema);
    }

    public async Task<Cinema> Handle(AddCinemaCommand request, CancellationToken cancellationToken)
    {
      return await _repository.SaveAsync(request.Cinema);
    }

    public async Task<IEnumerable<Cinema>> Handle(GetCinemasQuery request, CancellationToken cancellationToken)
    {
      return await _repository.GetAllAsync();
    }

    public async Task<Hall> Handle(AddHallToCinemaCommand request, CancellationToken cancellationToken)
    {
      return await _repository.AddHall(request.Id, request.Hall);
    }
  }
}
