using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Client.FormModels
{
    public class TicketBuyingEmailModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
