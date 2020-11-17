using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Context;
using TicketReservationSystem.Server.Data.Repository.Abstraction;
using TicketReservationSystem.Server.Models;
using TicketReservationSystem.Server.Models.DTO;
using TicketReservationSystem.Server.Data.Mapper;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
      var movie = _context.Movies.FirstOrDefault(movie => movie.MovieID == entityId);
      if (movie != null)
      {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
      }
    }

    public async Task DeleteAsync(int entityId)
    {
      var movie = _context.Movies.FirstOrDefault(movie => movie.MovieID == entityId);
      if (movie != null)
      {
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
      }
    }

    public async Task<Movie> GetAsync(int id)
    {
      return await _context.Movies.FirstOrDefaultAsync(Movie => Movie.MovieID == id);
    }

    public IEnumerable<Movie> GetAll()
    {
      return _context.Movies.ToList();
    }

    public Movie Save(Movie entity)
    {
      _context.Movies.Add(entity);
      _context.SaveChanges();
      return entity;
    }

    public async Task<Movie> SaveAsync(Movie entity)
    {
      await _context.Movies.AddAsync(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public Movie Update(int id, Movie entity)
    {
      var movie = _context.Movies.FirstOrDefault(movie => movie.MovieID == id);
      if (movie != null)
      {
        movie = _mapper.Map<Movie>(entity);
        return movie;
      }
      return null;
    }



    public async Task<Movie> UpdateAsync(int id, Movie entity)
    {
      var movie = await _context.Movies.FirstOrDefaultAsync(movie => movie.MovieID == id);
      if (movie != null)
      {
        movie = _mapper.Map<Movie>(entity);
        movie.Title = entity.Title;
        await _context.SaveChangesAsync();
        return movie;
      }
      return null;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
      return await _context.Movies.ToListAsync();
    }
  }
}
