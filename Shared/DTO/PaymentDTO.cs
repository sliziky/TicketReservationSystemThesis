using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Shared.DTO
{
    public class PaymentDTO
    {
        public int TotalPrice { get; set; }
        public Reservation Reservation { get; set; }

  }
}
