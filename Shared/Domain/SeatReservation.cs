using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Shared.Domain
{
    public class SeatReservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatReservationID { get; set; }
        public ReservationSeatStatus Status { get; set; }
        public int Price { get; set; }
        public List<Seat> Seats { get; set; }
        public MovieShow Show { get; set; }
        public Reservation Reservation { get; set; }
    }
    public enum ReservationSeatStatus { 
        Free,
        Reserved,
        Bought
    }
}
