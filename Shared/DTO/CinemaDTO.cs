using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Shared.DTO
{ 
    public class CinemaDTO
    {
        public string Name { get; set; }
        public string City { get; set; }
        public List<Hall> Halls { get; set; }
    }
}
