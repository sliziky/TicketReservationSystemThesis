﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.UserCQRS
{
    public class DeleteUserCommand : IRequest<User>
    {
        public int Id;
    }
}
