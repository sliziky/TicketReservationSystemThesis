using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.PaymentsCQRS.Queries
{
    public class GetPaymentQuery : IRequest<Payment>
    {
        public int Id { get; set; }
    }
}
