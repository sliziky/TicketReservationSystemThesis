using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.PaymentsCQRS.Commands
{
    public class AddSessionIdCommand : IRequest<Payment>
    {
        public int PaymentId { get; set; }
        public string Id { get; set; }
    }
}
