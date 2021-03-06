using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.DTO;

namespace TicketReservationSystem.Server.Data.Repository.Abstraction
{
  public interface IRepository<TEntity> where TEntity : class, new()
  {
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> GetAsync(int id);

    TEntity Update(int id, TEntity entity);
    Task<TEntity> UpdateAsync(int id, TEntity entity);


    TEntity Save(TEntity entity);

    Task<TEntity> SaveAsync(TEntity entity);


    void Delete(int entityId);
    Task<TEntity> DeleteAsync(int entityId);
  }
}
