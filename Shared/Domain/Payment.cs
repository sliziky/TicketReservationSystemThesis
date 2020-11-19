using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Shared.Domain
{
    public class Payment
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID { get; set; }
        public int TotalPrice { get; set; }
        public DateTime Created { get; set; }
        public Reservation Reservation { get; set; }
        public int ReservationID { get; set; }
    }
}
