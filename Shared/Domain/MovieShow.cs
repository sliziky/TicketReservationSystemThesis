using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Shared.Domain
{
  public class MovieShow
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int MovieShowId { get; set; }
    public DateTime Start { get; set; }
    public DateTime Date { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    public int HallId { get; set; }
    public Hall Hall { get; set; }
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    public List<SeatReservation> ReservationSeats { get; set; } = new List<SeatReservation>();


    }
}
