using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Shared.DTO
{
    public class ReservationSeatDTO
    {
        public ReservationSeatStatus Status { get; set; }
        public int Price { get; set; }
        public Seat Seat { get; set; }
        public MovieShow Show { get; set; }
        public Reservation Reservation { get; set; }
    }
    public enum ReservationSeatStatus
    {
        Free,
        Reserved,
        Bought
    }
}
