using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Shared.DTO
{
    public class AdminDTO
    {
        public User User { get; set; }
        public int UserID { get; set; }
    }
}
