using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.UserCQRS
{
    public class AuthenticateUserCommand : IRequest<bool>
    {
        public User User { get; set; }
    }
}
