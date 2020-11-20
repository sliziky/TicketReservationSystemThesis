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
    public int SeatId { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
        public SeatType Type { get; set; }
    [ForeignKey("HallId")]
    public int HallId { get; set; }
    public Hall Hall { get; set; }
    public int? SeatReservationId { get; set; }
    public SeatReservation SeatReservation { get; set; }
    }
}
