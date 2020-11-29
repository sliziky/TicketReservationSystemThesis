using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.CQRS.SeatsCQRS.Queries
{
    public class GetIsSeatReservedQuery : IRequest<bool>
    {
        public int ShowId { get; set; }
        public int SeatId { get; set; }
    }
}
