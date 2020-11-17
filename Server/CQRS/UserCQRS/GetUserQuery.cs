using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;
namespace TicketReservationSystem.Server.CQRS.UserCQRS
{
  public class GetUserQueryId : IRequest<User> { public int Id { get; set; } }
  public class GetUserQueryEmail : IRequest<User> { public string Email { get; set; } }

  public class GetUsersQuery : IRequest<IEnumerable<User>> {  }

}
