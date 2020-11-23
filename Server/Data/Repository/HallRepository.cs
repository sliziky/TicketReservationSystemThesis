using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Context;
using TicketReservationSystem.Server.Data.Repository.Abstraction;
using TicketReservationSystem.Server.Extensions;
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
      var hall = _context.Halls.FirstOrDefault(hall => hall.HallId == entityId);
      if (hall != null) {
        _context.Halls.Remove(hall);
        await _context.SaveChangesAsync();
      }
      return hall;
    }


    public async Task<IEnumerable<Hall>> GetAllAsync()
    {
      return await _context.Halls.Include(h => h.Cinema).Include(h => h.Shows).Include(h => h.Seats).ToListAsync();
    }

    public Task<Hall> GetAsync(int id)
    {
      return _context.Halls.Include(h => h.Cinema).Include(h => h.Shows).Include(h => h.Seats).FirstOrDefaultAsync(hall => hall.HallId == id);
    }

    public Hall Save(Hall entity)
    {
      throw new NotImplementedException();
    }

    public async Task<Hall> MarkHallObsolete(int hallId)
    {
      var hall = _context.Halls.Include(h => h.Cinema).Include(h => h.Seats).Include(h => h.Shows).FirstOrDefault(hall => hall.HallId == hallId);
      if (hall == null) { return null; }
      hall.IsObsolete = true;
      await _context.SaveChangesAsync();
      return hall;
    }

    public async Task<Hall> SaveAsync(Hall entity)
    {
      var hall = _context.Halls.Include(h => h.Cinema).Include(h => h.Shows).FirstOrDefault(hall => hall.Cinema.CinemaId == entity.Cinema.CinemaId && hall.Name == entity.Name);
      if (hall == null)
      {
        entity.Cinema = _context.Cinemas.Find(entity.CinemaId);
        await _context.Halls.AddAsync(entity);
        await _context.SaveChangesAsync();
      }
      return hall;
    }

    public async Task<IEnumerable<Hall>> GetNonObsolete()
    {
      return await _context.Halls.Where(h => !h.IsObsolete).ToListAsync();
    }

    public Hall Update(int id, Hall entity)
    {
      throw new NotImplementedException();
    }

    public async Task<Seat> AddSeat(int hallId, Seat seat)
    {
      var hall = await _context.Halls.Include(c => c.Seats).Include(c => c.Shows).Include(c => c.Cinema).FirstOrDefaultAsync(h => h.HallId == hallId);
      if (hall == null) { return null; }
      var seatFound = hall.Seats.FirstOrDefault(s => s.Index == seat.Index && s.Row == seat.Row);
      if (seatFound != null) { return null; }
      seat.HallId = hallId;
      _context.Seats.Add(seat);
      await _context.SaveChangesAsync();
      return seat;
    }

    public async Task<Hall> UpdateAsync(int id, Hall entity)
    {
      var hall = _context.Halls.Include(h => h.Seats).Include(h => h.Shows).Include(h => h.Cinema).FirstOrDefault(hall => hall.HallId == id);
      if (hall != null)
      {
        hall.Cinema = _context.Cinemas.Find(hall.CinemaId);
        hall.Name = entity.Name;
        hall.Seats = entity.Seats;
        hall.Rows = entity.Rows;
        hall.Capacity = entity.Capacity;
        hall.Shows = entity.Shows;
        hall.Seats = entity.Seats;
        await _context.SaveChangesAsync();
      }
      return hall;
    }

    public async Task<Seat> UpdateSeat (int seatId, Seat seat)
    {
      var seatFound = _context.Seats.Include(s => s.Hall).Include(s => s.SeatReservation).FirstOrDefault(s => s.SeatId == seatId);
      if (seatFound == null) { return null; }
      seatFound.Index = seat.Index;
      seatFound.Number = seat.Number;
      seatFound.Row = seat.Row;
      seatFound.Status = seat.Status;
      seatFound.Type = seat.Type;
      await _context.SaveChangesAsync();
      return seat;
    }

    public Task<IEnumerable<Hall>> DeleteAllAsync()
    {
      _context.DeleteAll<Hall>();
      return null;
    }
  }
}
