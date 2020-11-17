using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace TicketReservationSystem.Shared.Domain
{
    public class Hall
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HallID { get; set; }
        public string Name { get; set; }
        public uint Capacity { get; set; }
        public Cinema Cinema { get; set; }
        public List<Seat> Seats { get; set; }
        public List<MovieShow> Shows { get; set; }
    }
}
