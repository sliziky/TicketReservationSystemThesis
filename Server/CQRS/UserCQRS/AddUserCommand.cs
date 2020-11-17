using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Models;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.UserCQRS
{
  public class AddUserCommand : IRequest<User> { public User User; }
}
