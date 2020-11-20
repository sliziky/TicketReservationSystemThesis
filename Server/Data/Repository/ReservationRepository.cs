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
  public class ReservationRepository : IRepository<Reservation>
  {
    private MyContext _context;
    private IMapper _mapper;
    public ReservationRepository(MyContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public void Delete(int entityId)
    {
      throw new NotImplementedException();
    }
    public async Task<Reservation> AddReservation(Reservation r)
    {
      var reservation = await _context.Reservations.Include(res => res.MovieShow).Include(res => res.Payment).FirstOrDefaultAsync(res =>
      res.Created == r.Created && res.MovieShowId == r.MovieShowId);
      if (reservation != null) { return null; }
      r.MovieShow = _context.MovieShows.Find(r.MovieShowId);
      await _context.Reservations.AddAsync(r);
      await _context.SaveChangesAsync();
      return r;
    }

    public async Task<Reservation> DeleteAsync(int entityId)
    {
      var reservation = await _context.Reservations.Include(res => res.MovieShow).Include(res => res.Payment).FirstOrDefaultAsync(res => res.ReservationId == entityId);
      if (reservation != null) {
        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
      }
      return reservation;
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync()
    {
      return await _context.Reservations.Include(res => res.MovieShow).Include(res => res.Payment).ToListAsync();
    }

    public Task<Reservation> GetAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Reservation Save(Reservation entity)
    {
      throw new NotImplementedException();
    }

    public Task<Reservation> SaveAsync(Reservation entity)
    {
      throw new NotImplementedException();
    }

    public Reservation Update(int id, Reservation entity)
    {
      throw new NotImplementedException();
    }

    public Task<Reservation> UpdateAsync(int id, Reservation entity)
    {
      throw new NotImplementedException();
    }
  }
}
