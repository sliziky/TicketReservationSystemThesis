using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Client.FormModels
{
  public class BuyTicketsModel
  {
    [EmailAddress]
    [Required]
    public string EmailToSendTickets { get; set; }
  }
}
