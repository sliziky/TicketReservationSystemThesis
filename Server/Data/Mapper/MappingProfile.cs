using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Models;
using TicketReservationSystem.Server.Models.DTO;

namespace TicketReservationSystem.Server.Data.Mapper
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      // Add as many of these lines as you need to map your objects
      CreateMap<MovieDTO, Movie>();
      CreateMap<Movie, MovieDTO>();
    }
  }
}
