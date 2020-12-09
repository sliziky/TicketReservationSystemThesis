using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.ShowCQRS.Queries
{
    public class GetShowsForDay : IRequest<IEnumerable<MovieShow>>
    {
        public DateTime Day { get; set; }
    }
}
