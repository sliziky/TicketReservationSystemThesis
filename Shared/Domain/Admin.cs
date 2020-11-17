using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Shared.Domain
{
    public class Admin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminID { get; set; }
        public User User { get; set; }
        public int UserID { get; set;}
    }
}
