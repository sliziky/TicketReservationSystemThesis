using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Shared.Domain
{
    public class SeatReservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SeatReservationId { get; set; }
        public int Price { get; set; }
        public List<Seat> Seats { get; set; }
        public int MovieShowId { get; set; }
        public MovieShow Show { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
