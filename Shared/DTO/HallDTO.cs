using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Shared.DTO
{
    public class HallDTO
    {
        public string Name { get; set; }
        public uint Capacity { get; set; }
        public Cinema Cinema { get; set; }
        public int CinemaId { get; set; }
    public int Rows { get; set; }

    public List<SeatDTO> Seats { get; set; }
        public List<MovieShow> Shows { get; set; }
    }
}
