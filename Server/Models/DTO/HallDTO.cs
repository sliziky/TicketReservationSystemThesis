using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.Models.DTO
{
    public class HallDTO
    {
        public string Name { get; set; }
        public uint Capacity { get; set; }
        public Cinema Cinema { get; set; }
        public List<Seat> Seats { get; set; }
        public List<MovieShow> Shows { get; set; }
    }
}
