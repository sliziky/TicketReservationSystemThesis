using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Shared.Domain
{
    public class Admin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int AdminId { get; set; }
        public User User { get; set; }
        public int UserId { get; set;}
    }
}
