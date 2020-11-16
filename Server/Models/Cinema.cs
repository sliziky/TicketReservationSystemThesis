using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace TicketReservationSystem.Server.Models
{
    public class Cinema
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CinemaID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public List<Hall> Halls{ get; set; }
    }
}
