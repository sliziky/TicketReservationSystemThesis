using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.PaymentsCQRS.Queries;
using TicketReservationSystem.Server.Data.Repository;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.PaymentsCQRS
{
  public class PaymentHandler
    : IRequestHandler<GetPaymentsQuery, IEnumerable<Payment>>
  {
    private readonly PaymentRepository _repository;

    public PaymentHandler(PaymentRepository repository)
    {
      _repository = repository;
    }
    public async Task<IEnumerable<Payment>> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
    {
      return await _repository.GetAllAsync();
    }
  }
}
