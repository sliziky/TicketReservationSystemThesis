using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Shared.Domain
{
    public class Reservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int ReservationID { get; set; }
        public ReservationStatus Status { get; set; }
        public DateTime Created { get; set; }
    public List<SeatReservation> ReservationSeats { get; set; } = new List<SeatReservation>();
    public MovieShow MovieShow { get; set; } = new MovieShow();
    public Payment Payment { get; set; } = new Payment();


    }
    public enum ReservationStatus { 
        Paid,
        NotPaid
    }
}
