using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.CQRS.AdminCQRS.Queries
{
    public class GetIsUserAdminQuery : IRequest<bool>
    {
        public int UserId { get; set; }
    }
}
