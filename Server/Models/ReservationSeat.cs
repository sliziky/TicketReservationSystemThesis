using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.Models
{
    public class ReservationSeat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationSeatID { get; set; }
        public ReservationSeatStatus Status { get; set; }
        public int Price { get; set; }
        public Seat Seat { get; set; }
        public MovieShow Show { get; set; }
        public Reservation Reservation { get; set; }
    }
    public enum ReservationSeatStatus { 
        Free,
        Reserved,
        Bought
    }
}
