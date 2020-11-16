using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.Models.DTO
{
    public class SeatDTO
    {
        public int Number { get; set; }
        public SeatType Type { get; set; }
        public Hall Hall { get; set; }
        public List<ReservationSeat> ReservationSeats { get; set; }
    }
    public enum SeatType
    {
        Classic,
        Disabled,
        Handicapped
    }
}
