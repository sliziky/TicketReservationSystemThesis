using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Shared.Domain
{
    public class Seat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int SeatID { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
        public SeatType Type { get; set; }
    public Hall Hall { get; set; } = new Hall();
    public SeatReservation SeatReservation { get; set; } = new SeatReservation();
    }
}
