using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.AdminCQRS.Queries
{
    public class GetAdminsQuery : IRequest<IEnumerable<Admin>>
    {
    }
}
