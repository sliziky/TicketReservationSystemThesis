using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.Models
{
    public class Payment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID { get; set; }
        public int TotalPrice { get; set; }
        public DateTime Created { get; set; }
        public Reservation Reservation { get; set; }
        public int ReservationID { get; set; }
    }
}
