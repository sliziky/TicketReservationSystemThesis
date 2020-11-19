using AutoMapper;
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
  public class HallRepository : IRepository<Hall>
  {
    private MyContext _context;
    private IMapper _mapper;
    public HallRepository(MyContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public void Delete(int entityId)
    {
      throw new NotImplementedException();
    }

    public async Task<Hall> DeleteAsync(int entityId)
    {
      var hall = _context.Halls.FirstOrDefault(hall => hall.HallID == entityId);
      if (hall != null) {
        _context.Halls.Remove(hall);
        await _context.SaveChangesAsync();
      }
      return hall;
    }

    public IEnumerable<Hall> GetAll()
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<Hall>> GetAllAsync()
    {
      return await _context.Halls.ToListAsync();
    }

    public Task<Hall> GetAsync(int id)
    {
      return _context.Halls.FirstOrDefaultAsync(hall => hall.HallID == id);
    }

    public Hall Save(Hall entity)
    {
      throw new NotImplementedException();
    }

    public async Task<Hall> SaveAsync(Hall entity)
    {
      var hall = _context.Halls.FirstOrDefault(hall => hall.Cinema.CinemaID == entity.Cinema.CinemaID && hall.Name == entity.Name);
      if (hall == null)
      {
        await _context.Halls.AddAsync(entity);
        await _context.SaveChangesAsync();
      }
      return hall;
    }

    public Hall Update(int id, Hall entity)
    {
      throw new NotImplementedException();
    }

    public async Task<Hall> UpdateAsync(int id, Hall entity)
    {
      var hall = _context.Halls.FirstOrDefault(hall => hall.HallID == id);
      if (hall != null)
      {
        hall.Name = entity.Name;
        hall.Seats = entity.Seats;
        hall.Shows = entity.Shows;
        await _context.SaveChangesAsync();
      }
      return hall;
    }
  }
}
