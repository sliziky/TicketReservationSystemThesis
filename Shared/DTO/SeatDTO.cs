using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Shared.DTO
{
    public class SeatDTO
    {
        public int Number { get; set; }
        public SeatType Type { get; set; }
        public Hall Hall { get; set; }
        public List<SeatReservation> ReservationSeats { get; set; }
    }
    public enum SeatType
    {
        Classic,
        Disabled,
        Handicapped
    }
}
