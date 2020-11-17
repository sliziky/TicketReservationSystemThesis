using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Data.Repository;
using TicketReservationSystem.Server.Models;
using TicketReservationSystem.Shared.Domain;


namespace TicketReservationSystem.Server.CQRS.UserCQRS
{
  public class UserHandler :
    IRequestHandler<AddUserCommand, User>,
    IRequestHandler<GetUserQueryId, User>,
    IRequestHandler<GetUserQueryEmail, User>,
    IRequestHandler<GetUsersQuery, IEnumerable<User>>
  {
    private readonly UserRepository _repository;

    public UserHandler(UserRepository repository)
    {
      _repository = repository;
    }

    public async Task<User> Handle(GetUserQueryId request, CancellationToken cancellationToken)
    {
      return await _repository.GetAsync(request.Id);
    }

    public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
      return await _repository.SaveAsync(request.User);
    }

    public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
      return await _repository.GetAllAsync();
    }

    public async Task<User> Handle(GetUserQueryEmail request, CancellationToken cancellationToken)
    {
      return await _repository.GetAsync(request.Email);
    }
  }
}
