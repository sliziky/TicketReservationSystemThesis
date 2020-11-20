using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.SeatReservationCQRS.Commands;
using TicketReservationSystem.Server.CQRS.SeatReservationCQRS.Queries;
using TicketReservationSystem.Server.Data.Repository;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.SeatReservationCQRS
{
  public class SeatReservationHandler :
    IRequestHandler<AddSeatReservationCommand, SeatReservation>,
    IRequestHandler<DeleteSeatReservationCommand, SeatReservation>,
    IRequestHandler<GetSeatReservationsQuery, IEnumerable<SeatReservation>>,
    IRequestHandler<AddSeatToSeatReservationCommand, SeatReservation>
  {
    private readonly SeatReservationRepository _repository;

    public SeatReservationHandler(SeatReservationRepository repository)
    {
      _repository = repository;
    }

    public async Task<SeatReservation> Handle(DeleteSeatReservationCommand request, CancellationToken cancellationToken)
    {
      return await _repository.DeleteAsync(request.Id);
    }

    public async Task<IEnumerable<SeatReservation>> Handle(GetSeatReservationsQuery request, CancellationToken cancellationToken)
    {
      return await _repository.GetAllAsync();
    }

    public async Task<SeatReservation> Handle(AddSeatReservationCommand request, CancellationToken cancellationToken)
    {
      return await _repository.SaveAsync(request.SeatReservation);
    }

    public async Task<SeatReservation> Handle(AddSeatToSeatReservationCommand request, CancellationToken cancellationToken)
    {
      return await _repository.AddSeat(request.Id, request.Seat);
    }
  }
}
