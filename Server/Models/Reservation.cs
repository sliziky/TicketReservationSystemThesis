using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.Models
{
    public class Reservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationID { get; set; }
        public ReservationStatus Status { get; set; }
        public DateTime Created { get; set; }
        public List<SeatReservation> ReservationSeats { get; set; }
        public MovieShow MovieShow { get; set; }
        public Payment Payment { get; set; }


    }
    public enum ReservationStatus { 
        Paid,
        NotPaid
    }
}
