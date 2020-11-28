using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.ReservationsCQRS.Commands;
using TicketReservationSystem.Server.CQRS.ReservationsCQRS.Queries;
using TicketReservationSystem.Server.Data.Repository;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.ReservationsCQRS
{
  public class ReservationsHandler :
    IRequestHandler<AddReservationCommand, Reservation>,
    IRequestHandler<GetReservationQuery, Reservation>,
    IRequestHandler<GetReservationsQuery, IEnumerable<Reservation>>,
    IRequestHandler<DeleteReservationCommand, Reservation>,
    IRequestHandler<AddPaymentToReservationCommand, Reservation>,
        IRequestHandler<GetActiveReservationsQuery, IEnumerable<Reservation>>,
        IRequestHandler<MarkReservationPaid, Reservation>

  {

    private readonly ReservationRepository _repository;

    public ReservationsHandler(ReservationRepository repository)
    {
      _repository = repository;
    }
    public async Task<IEnumerable<Reservation>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
    {
      return await _repository.GetAllAsync();
    }

    public async Task<Reservation> Handle(AddReservationCommand request, CancellationToken cancellationToken)
    {
      return await _repository.AddReservation(request.Reservation);
    }

    public async Task<Reservation> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
      return await _repository.DeleteAsync(request.Id);
    }

    public async Task<Reservation> Handle(GetReservationQuery request, CancellationToken cancellationToken)
    {
      return await _repository.GetAsync(request.Id);
    }

    public async Task<Reservation> Handle(AddPaymentToReservationCommand request, CancellationToken cancellationToken)
    {
      return await _repository.AddPayment(request.Id, request.Payment);
    }

        public async Task<IEnumerable<Reservation>> Handle(GetActiveReservationsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetActiveAsync();
        }

        public async Task<Reservation> Handle(MarkReservationPaid request, CancellationToken cancellationToken)
        {
            return await _repository.MarkReservationPaid(request.Id);
        }
    }
}
