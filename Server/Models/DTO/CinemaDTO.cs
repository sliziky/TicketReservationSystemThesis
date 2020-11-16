using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.Models.DTO
{
    public class CinemaDTO
    {
        public string Name { get; set; }
        public string City { get; set; }
        public List<Hall> Halls { get; set; }
    }
}
