using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.Models.DTO
{
    public class PaymentDTO
    {
        public int TotalPrice { get; set; }
        public Reservation Reservation { get; set; }
        public int ReservationID { get; set; }
    }
}
