﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Models;
using TicketReservationSystem.Server.Models.DTO;

namespace TicketReservationSystem.Server.Data.Mapper
{
    public class Mapper
    {
        public IMapper iMapper { get; set; }
        public Mapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Movie, MovieDTO>();
            });
            iMapper = config.CreateMapper();
        }
    }
}
