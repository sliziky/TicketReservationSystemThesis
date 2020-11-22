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
  public class ShowRepository : IRepository<MovieShow>
  {
    private readonly MyContext _context;

    public ShowRepository(MyContext context)
    {
      _context = context;
    }
    public void Delete(int entityId)
    {
      throw new NotImplementedException();
    }

    public async Task<MovieShow> DeleteAsync(int entityId)
    {
      var foundShow = await _context.MovieShows.Include(s => s.ReservationSeats).Include(s => s.Hall).Include(s => s.Movie).FirstOrDefaultAsync(s => s.MovieShowId == entityId);
      if (foundShow != null) {
        _context.MovieShows.Remove(foundShow);
        await _context.SaveChangesAsync();
      }
      return foundShow;
    }

    public async Task<IEnumerable<MovieShow>> GetAllAsync()
    {
      return await _context.MovieShows.Include(s => s.Hall).Include(s => s.Movie).ToListAsync();
    }

    public async Task<MovieShow> GetAsync(int id)
    {
      return await _context.MovieShows.Include(m => m.Hall).Include(m => m.Movie).FirstOrDefaultAsync(s => s.MovieShowId == id);

    }

    public async Task<MovieShow> AddMovieShow(int hallId, int movieId, MovieShow show) {
      var foundShow = await _context.MovieShows.Include(s => s.ReservationSeats).Include(s => s.Hall).Include(s => s.Movie).FirstOrDefaultAsync(s => s.HallId == show.HallId && s.MovieId == show.MovieId && s.Start == show.Start);
      if (foundShow != null) { return null; }
      show.HallId = hallId;
      show.MovieId = movieId;
      await _context.MovieShows.AddAsync(show);
      await _context.SaveChangesAsync();
      return show;
    }
    public MovieShow Save(MovieShow entity)
    {
      throw new NotImplementedException();
    }

    public async Task<MovieShow> SaveAsync(MovieShow entity)
    {
      return null;
      //var show = _context.MovieShows.Include(s => s..FirstOrDefaultAsync(s => s.MovieId == entity.MovieId && s.Start == entity.Start);
      //if (show == null) {
      //  _context.MovieShows.Add(entity);
      //  await _context.SaveChangesAsync();
      //}
      //return show;
    }

    public MovieShow Update(int id, MovieShow entity)
    {
      throw new NotImplementedException();
    }

    public Task<MovieShow> UpdateAsync(int id, MovieShow entity)
    {
      throw new NotImplementedException();
    }

    //public async Task<SeatReservation> AddSeatToReservation(SeatReservation sr) {
    //  var seat = await _context.ReservationSeats.Include(s => s.Reservation).Include(s => s.Seats).Include(s => s.Show).FirstOrDefaultAsync(s => s.SeatReservationId == sr.SeatReservationId);
    //  if (seat != null) { return null; }
    //  seat.
    //  return seat;
    //}

    Task<MovieShow> IRepository<MovieShow>.GetAsync(int id)
    {
      throw new NotImplementedException();
    }
  }
}