using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.Data.Repository.Abstraction
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(int id);

        TEntity Save(TEntity entity);

        void Delete(int entityId);
    }
}
