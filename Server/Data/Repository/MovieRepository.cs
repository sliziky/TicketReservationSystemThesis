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
    public class MovieRepository : IRepository<MovieDTO>
    {
        private MyContext _context;
        private IMapper _mapper;
        public MovieRepository(MyContext context)
        {
            _context = context;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Movie, MovieDTO>();
            });
            _mapper = config.CreateMapper();
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public MovieDTO Save(MovieDTO entity)
        {
            throw new NotImplementedException();
        }

        public MovieDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieDTO> GetAll()
        {
            var x = 2;
            return _context.Movies.ToList().Select(movie => _mapper.Map<Movie, MovieDTO>(movie));
        }
    }
}
