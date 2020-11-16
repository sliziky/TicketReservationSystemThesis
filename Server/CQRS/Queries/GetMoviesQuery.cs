using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Context;
using TicketReservationSystem.Server.Data.Repository;
using TicketReservationSystem.Server.Models.DTO;

namespace TicketReservationSystem.Server.CQRS.Queries
{
    public class GetMoviesQuery
    {
        public class Query : IRequest<IEnumerable<MovieDTO>> { }

        public class Handler : RequestHandler<Query, IEnumerable<MovieDTO>>
        {
            private readonly MovieRepository _repository;

            public Handler(MovieRepository repository)
            {
                _repository = repository;
            }

            protected override IEnumerable<MovieDTO> Handle(Query request)
            {
                return _repository.GetAll();
            }
        }
    }
}
