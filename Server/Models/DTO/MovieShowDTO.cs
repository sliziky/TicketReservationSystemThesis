using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.Models.DTO
{
    public class MovieShowDTO
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Movie Movie { get; set; }
        public Hall Hall { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<SeatReservation> ReservationSeats { get; set; }
    }
}
