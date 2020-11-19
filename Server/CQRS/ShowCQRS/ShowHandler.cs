using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.ShowCQRS.Commands;
using TicketReservationSystem.Server.CQRS.ShowCQRS.Queries;
using TicketReservationSystem.Server.Data.Repository;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.ShowCQRS
{
  public class ShowHandler :
    IRequestHandler<GetShowsQuery, IEnumerable<MovieShow>>,
    IRequestHandler<DeleteShowCommand, MovieShow>
  {

    private readonly ShowRepository _repository;

    public ShowHandler(ShowRepository repository)
    {
      _repository = repository;
    }
    public async Task<IEnumerable<MovieShow>> Handle(GetShowsQuery request, CancellationToken cancellationToken)
    {
      return await _repository.GetAllAsync();
    }

    public async Task<MovieShow> Handle(DeleteShowCommand request, CancellationToken cancellationToken)
    {
      return await _repository.DeleteAsync(request.Id);
    }
  }
}
