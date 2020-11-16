using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.Models.DTO
{
    public class ReservationDTO
    {

        public ReservationStatus Status { get; set; }
        public DateTime Created { get; set; }
        public List<SeatReservation> ReservationSeats { get; set; }
        public MovieShow MovieShow { get; set; }
        public Payment Payment { get; set; }

    }
    public enum ReservationStatus
    {
        Paid,
        NotPaid
    }
}
