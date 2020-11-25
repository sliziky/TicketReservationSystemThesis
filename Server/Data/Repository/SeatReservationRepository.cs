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
  public class SeatReservationRepository : IRepository<SeatReservation>
  {
    private readonly MyContext _context;

    public SeatReservationRepository(MyContext context)
    {
      _context = context;
    }
    public void Delete(int entityId)
    {
      throw new NotImplementedException();
    }

    public async Task<SeatReservation> DeleteAsync(int entityId)
    {
      var sr = await _context.ReservationSeats
        .Include(r => r.Reservation)
        .Include(r => r.Seats)
        .Include(r => r.Show).FirstOrDefaultAsync(r => r.SeatReservationId == entityId);
      if (sr != null) {
        _context.ReservationSeats.Remove(sr);
        await _context.SaveChangesAsync();
      }
      return sr;
    }

    public async Task<IEnumerable<SeatReservation>> GetAllAsync()
    {
      return await _context.ReservationSeats
        .Include(r => r.Reservation)
        .Include(r => r.Seats)
        .Include(r => r.Show).ToListAsync();
    }

    public async Task<SeatReservation> GetAsync(int id)
    {
      var sr = await _context.ReservationSeats.Include(r => r.Reservation)
       .Include(r => r.Seats)
       .Include(r => r.Show).FirstOrDefaultAsync(s => s.SeatReservationId == id);
      return sr;
    }

    public SeatReservation Save(SeatReservation entity)
    {
      throw new NotImplementedException();
    }

    public async Task<SeatReservation> SaveAsync(SeatReservation entity)
    {
      var sr = await _context.ReservationSeats
       .Include(r => r.Reservation)
       .Include(r => r.Seats)
       .Include(r => r.Show).FirstOrDefaultAsync(r => r.MovieShowId == entity.MovieShowId && r.ReservationId == entity.ReservationId);
      if (sr == null)
      {
        entity.Reservation = _context.Reservations.Find(entity.ReservationId);
        entity.Show = _context.MovieShows.Find(entity.Reservation.MovieShowId);
        _context.ReservationSeats.Add(entity);
        await _context.SaveChangesAsync();
      }
      return entity;
    }

    public async Task<SeatReservation> AddSeat(int seatReservationId, Seat entity)
    {
      var sr = await _context.ReservationSeats
       .Include(r => r.Reservation)
       .Include(r => r.Seats)
       .Include(r => r.Show).FirstOrDefaultAsync(r => r.SeatReservationId == seatReservationId);
      if (sr != null)
      {
        var seat = _context.Seats.Find(entity.SeatId);
        sr.Seats.Add(seat);
        await _context.SaveChangesAsync();
      }
      return sr;
    }

    public SeatReservation Update(int id, SeatReservation entity)
    {
      throw new NotImplementedException();
    }

    public Task<SeatReservation> UpdateAsync(int id, SeatReservation entity)
    {
      throw new NotImplementedException();
    }
  }
}
