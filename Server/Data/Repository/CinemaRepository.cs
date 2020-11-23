using Microsoft.AspNetCore.JsonPatch;
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
      var movie = await _context.Cinemas.FirstOrDefaultAsync(cinema => cinema.CinemaId == entityId);
      if (movie != null) {
        _context.Cinemas.Remove(movie);
        await _context.SaveChangesAsync();
        return movie;
      }
      return null;
    }


    public async Task<IEnumerable<Cinema>> GetAllAsync()
    {
      return await _context.Cinemas.Include(h => h.Halls).ToListAsync();
    }

    public async Task<Hall> AddHall(int cinemaId, Hall hall) {
      var cinema = await _context.Cinemas.Include(c => c.Halls).FirstOrDefaultAsync(c => c.CinemaId == cinemaId);
      if (cinema == null) { return null; }
      var hallFound = cinema.Halls.FirstOrDefault(cinema => cinema.HallId == hall.HallId);
      if (hallFound != null) { return null; }
      cinema.Halls.Add(hall);
      await _context.SaveChangesAsync();
      return hall;
    }


    public async Task<Cinema> GetAsync(int id)
    {
      return await _context.Cinemas.FirstOrDefaultAsync(cinema => cinema.CinemaId == id);
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
      var cinema = await _context.Cinemas.FirstOrDefaultAsync(cinema => cinema.CinemaId == id);
      if (cinema != null) {
        cinema.City = entity.City;
        cinema.GatewayApiKey = entity.GatewayApiKey;
        cinema.Name = entity.Name;
        await _context.SaveChangesAsync();
        return cinema;
      }
      return null;
    }


  }
}
