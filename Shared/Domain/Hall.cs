using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace TicketReservationSystem.Shared.Domain
{
    public class Hall
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int HallId { get; set; }
        public string Name { get; set; }
        public uint Capacity { get; set; }
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public int Rows { get; set; }
        public List<Seat> Seats { get; set; } = new List<Seat>();
        public List<MovieShow> Shows { get; set; } = new List<MovieShow>();
    }
}
