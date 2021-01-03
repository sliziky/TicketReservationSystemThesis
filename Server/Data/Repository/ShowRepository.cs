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
      var foundShow = await _context.MovieShows.Include(s => s.ReservationSeats).Include(s => s.Reservations).Include(s => s.Hall).Include(s => s.Movie).FirstOrDefaultAsync(s => s.MovieShowId == entityId);
      if (foundShow != null) {
        _context.MovieShows.Remove(foundShow);
        await _context.SaveChangesAsync();
      }
      return foundShow;
    }

    public async Task<IEnumerable<MovieShow>> GetAllAsync()
    {
        return await _context.MovieShows.Include(s => s.Movie).Include(s => s.Hall).ToListAsync();
    }
    public async Task<IEnumerable<MovieShow>> GetUpcomingShows()
    {
        var today = DateTime.Today;
        return await _context.MovieShows.Where(show => show.Date.Date >= today).ToListAsync();
    }

    public async Task<MovieShow> GetAsync(int id)
    {
            var shows = await _context.MovieShows.Include(m => m.Hall).Include(m => m.Movie).Include(s => s.ReservationSeats).Include(s => s.Reservations).ToListAsync();
            var show = shows.FirstOrDefault(s => s.MovieShowId == id);
            show.Hall = _context.Halls.ToList().FirstOrDefault(hall => hall.HallId == show.HallId);      
            return show;

    }
        public async Task<IEnumerable<MovieShow>> GetShowsForDay(DateTime date)
        {
            var shows = await _context.MovieShows.Include(m => m.Hall).Include(m => m.Movie).Include(s => s.ReservationSeats).Include(s => s.Reservations)
                .Where(i => i.Date.Date == date.Date).ToListAsync();
            return shows;
        }

    public async Task<MovieShow> AddMovieShow(int hallId, int movieId, MovieShow show) {
      var foundShow = await _context.MovieShows.Include(m => m.Hall).Include(m => m.Movie).Include(s => s.ReservationSeats).Include(s => s.Reservations).FirstOrDefaultAsync(s => s.HallId == show.HallId && s.MovieId == show.MovieId && s.Start == show.Start);
      if (foundShow != null) { return null; }
      var shows = await _context.MovieShows.Include(m => m.Hall).Include(m => m.Movie).Include(s => s.ReservationSeats).Include(s => s.Reservations).ToListAsync();
           // shows.Where(s => s.HallId == hallId && s.Date <= show.Date && s.Date.AddMinutes(s.Movie.Length));
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
    public async Task<IEnumerable<Reservation>> GetReservationsForShow(int showId)
    {
      var show = await _context.MovieShows.Include(s => s.Reservations).ThenInclude(s => s.Payment).Include(s => s.ReservationSeats).ThenInclude(rs => rs.Seats).FirstOrDefaultAsync(s => s.MovieShowId == showId);
      show.Reservations = show.Reservations.Where(r => !r.SoftDeleted).ToList();

     if (show == null) { return null; }
      return show.Reservations;
    }
    public async Task<IEnumerable<Seat>> GetReservedSeatsForShow(int showId)
    {
      var show = await _context.MovieShows.Include(s => s.ReservationSeats).ThenInclude(rs => rs.Seats).FirstOrDefaultAsync(s => s.MovieShowId == showId);
      if (show == null) { return null; }
      var result = new List<Seat>();
      foreach (var rs in show.ReservationSeats)
      {
        result.AddRange(rs.Seats);
      }
      return result;
    }
  }
}
