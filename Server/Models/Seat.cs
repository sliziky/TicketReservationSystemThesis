using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.Models
{
    public class Seat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatID { get; set; }
        public int Number { get; set; }
        public SeatType Type { get; set; }
        public Hall Hall { get; set; }
        public SeatReservation SeatReservation{ get; set; }
    }
    public enum SeatType { 
        Classic,
        Disabled,
        Handicapped
    }
}
