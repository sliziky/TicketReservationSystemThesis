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
  public class SeatRepository : IRepository<Seat>
  {
    private readonly MyContext _context;
    public SeatRepository(MyContext context)
    {
      _context = context;
    }

    public void Delete(int entityId)
    {
      throw new NotImplementedException();
    }

    public async Task<Seat> DeleteAsync(int entityId)
    {
      var seat = _context.Seats.FirstOrDefault(seat => seat.SeatId == entityId);
      if (seat != null)
      {
        _context.Seats.Remove(seat);
        await _context.SaveChangesAsync();
      }
      return seat;
    }

    public IEnumerable<Seat> GetAll()
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<Seat>> GetAllAsync()
    {
      return await _context.Seats.ToListAsync();
    }

    public Task<Seat> GetAsync(int id)
    {
      return _context.Seats.FirstOrDefaultAsync(seat => seat.SeatId == id);
    }

    public Seat Save(Seat entity)
    {
      throw new NotImplementedException();
    }

    public async Task<Seat> SaveAsync(Seat entity)
    {
      var seat = _context.Seats.FirstOrDefault(seat => seat.Hall == entity.Hall && seat.Number == entity.Number && seat.Row == entity.Row);
      if (seat == null)
      {
        await _context.Seats.AddAsync(seat);
        await _context.SaveChangesAsync();
      }
      return seat;
    }

    public Hall Update(int id, Seat entity)
    {
      throw new NotImplementedException();
    }

    public async Task<Seat> UpdateAsync(int id, Seat entity)
    {
      var seat = _context.Seats.FirstOrDefault(seat => seat.SeatId == id);
      if (seat != null)
      {
        seat.Hall = entity.Hall;
        seat.Number = entity.Number;
        seat.Row = entity.Row;
        seat.Type = entity.Type;
        await _context.SaveChangesAsync();
      }
      return seat;
    }

    Seat IRepository<Seat>.Update(int id, Seat entity)
    {
      throw new NotImplementedException();
    }
  }
}
