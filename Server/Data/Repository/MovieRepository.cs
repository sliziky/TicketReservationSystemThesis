using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Context;
using TicketReservationSystem.Server.Data.Repository.Abstraction;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.Data.Repository
{
  public class MovieRepository : IRepository<Movie>
  {
    private MyContext _context;
    private IMapper _mapper;
    public MovieRepository(MyContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public void Delete(int entityId)
    {
      var movie = _context.Movies.FirstOrDefault(movie => movie.MovieId == entityId);
      if (movie != null)
      {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
      }
    }

    public async Task<Movie> DeleteAsync(int entityId)
    {
      var movie = _context.Movies.FirstOrDefault(movie => movie.MovieId == entityId);
      if (movie != null)
      {
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
      }
      return movie;
    }

    public async Task<Movie> GetAsync(int id)
    {
      return await _context.Movies.Include(m => m.Shows).FirstOrDefaultAsync(Movie => Movie.MovieId == id);
    }


    public Movie Save(Movie entity)
    {
        _context.Movies.Add(entity);
        _context.SaveChanges();
      return entity;
    }

    public async Task<Movie> SaveAsync(Movie entity)
    {
      var movie = _context.Movies.FirstOrDefault(movie => movie.Title == entity.Title && movie.Released == entity.Released);
      if (movie == null)
      {
        await _context.Movies.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
      }
      return null;
    }

    public Movie Update(int id, Movie entity)
    {
      var movie = _context.Movies.FirstOrDefault(movie => movie.MovieId == id);
      if (movie != null)
      {
        movie = _mapper.Map<Movie>(entity);
        return movie;
      }
      return null;
    }



    public async Task<Movie> UpdateAsync(int id, Movie entity)
    {
      var movie = await _context.Movies.FirstOrDefaultAsync(movie => movie.MovieId == id);
      if (movie != null)
      {
        movie = _mapper.Map<Movie>(entity);
        movie.Title = entity.Title;
        await _context.SaveChangesAsync();
      }
      return movie;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
      return await _context.Movies.ToListAsync();
    }
  }
}
