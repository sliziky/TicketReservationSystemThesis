using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Context;
using TicketReservationSystem.Server.Data.Repository.Abstraction;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.Data.Repository
{
  public class CinemaRepository : IRepository<Cinema>
  {
    private readonly MyContext _context;

    public CinemaRepository(MyContext context)
    {
      _context = context;
    }

    public void Delete(int entityId)
    {
      throw new NotImplementedException();
    }


    public async Task<Cinema> DeleteAsync(int entityId)
    {
      var movie = await _context.Cinemas.FirstOrDefaultAsync(cinema => cinema.CinemaID == entityId);
      if (movie != null) {
        _context.Cinemas.Remove(movie);
        await _context.SaveChangesAsync();
        return movie;
      }
      return null;
    }

    public IEnumerable<Cinema> GetAll()
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<Cinema>> GetAllAsync()
    {
      return await _context.Cinemas.ToListAsync();
    }

    public async Task<Cinema> GetAsync(int id)
    {
      return await _context.Cinemas.FirstOrDefaultAsync(cinema => cinema.CinemaID == id);
    }

    public Cinema Save(Cinema entity)
    {
      throw new NotImplementedException();
    }

    public async Task<Cinema> SaveAsync(Cinema entity)
    {
      var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.City == entity.City && cinema.Name == entity.Name);
      // 409
      if (cinema != null)
      {
          return null;
      }
      await _context.Cinemas.AddAsync(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public Cinema Update(int id, Cinema entity)
    {
      throw new NotImplementedException();
    }

    public async Task<Cinema> UpdateAsync(int id, Cinema entity)
    {
      var cinema = await _context.Cinemas.FirstOrDefaultAsync(cinema => cinema.CinemaID == id);
      if (cinema != null) {
        cinema.City = entity.City;
        cinema.Halls = entity.Halls;
        cinema.Name = entity.Name;
        await _context.SaveChangesAsync();
        return entity;
      }
      return null;
    }


  }
}
