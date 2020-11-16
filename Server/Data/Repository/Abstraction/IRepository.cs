using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.Data.Repository.Abstraction
{
    public interface IRepository<TEntity, TEntityDTO>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(int id);

        TEntity Save(TEntityDTO entity);

        Task<TEntity> SaveAsync(TEntityDTO entity);


    void Delete(int entityId);
    }
}
