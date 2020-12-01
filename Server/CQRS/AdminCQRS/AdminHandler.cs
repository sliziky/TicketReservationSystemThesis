using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketReservationSystem.Server.CQRS.AdminCQRS.Queries;
using TicketReservationSystem.Server.Data.Repository;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.CQRS.AdminCQRS
{
    public class AdminHandler
        : IRequestHandler<GetAdminsQuery, IEnumerable<Admin>>,
        IRequestHandler<GetIsUserAdminQuery, bool>
    {

        private readonly AdminRepository _repository;

        public AdminHandler(AdminRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Admin>> Handle(GetAdminsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> Handle(GetIsUserAdminQuery request, CancellationToken cancellationToken)
        {
            return await _repository.IsUserAdmin(request.UserId);
        }
    }
}
