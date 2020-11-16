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

namespace TicketReservationSystem.Server.Data.Repository
{
    public class MovieRepository : IRepository<Movie, MovieDTO>
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
      throw new NotImplementedException();
    }

    public Movie Get(int id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> GetAll()
    {
      return _context.Movies.ToList();
    }

    public Movie Save(MovieDTO entity)
    {
      throw new NotImplementedException();
    }

    public async Task<Movie> SaveAsync(MovieDTO entity)
    {
      await _context.Movies.AddAsync(_mapper.Map<MovieDTO, Movie>(entity));
      await _context.SaveChangesAsync();
      return _mapper.Map<MovieDTO, Movie>(entity);
    }
  }
}
