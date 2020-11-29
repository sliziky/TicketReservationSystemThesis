using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.SeatsCQRS.Commands;
using TicketReservationSystem.Server.CQRS.SeatsCQRS.Queries;
using TicketReservationSystem.Server.Data.Repository;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.SeatsCQRS
{
  public class SeatsHandler :
    IRequestHandler<AddSeatCommand,Seat>,
    IRequestHandler<GetSeatsQuery, IEnumerable<Seat>>,
    IRequestHandler<DeleteSeatCommand, Seat>,
        IRequestHandler<GetIsSeatReservedQuery, bool>
  {
    private readonly SeatRepository _repository;

    public SeatsHandler(SeatRepository repository)
    {
      _repository = repository;
    }

    public async Task<Seat> Handle(AddSeatCommand request, CancellationToken cancellationToken)
    {
      return await _repository.SaveAsync(request.Seat); 
    }

    public async Task<IEnumerable<Seat>> Handle(GetSeatsQuery request, CancellationToken cancellationToken)
    {
      return await _repository.GetAllAsync();
    }

    public async Task<Seat> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
    {
      return await _repository.DeleteAsync(request.Id);
    }

    public async Task<bool> Handle(GetIsSeatReservedQuery request, CancellationToken cancellationToken)
    {
        return await _repository.IsSeatReserved(request.SeatId, request.ShowId);
    }
  }
}
