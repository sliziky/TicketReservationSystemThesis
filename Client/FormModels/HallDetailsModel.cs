using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Client.FormModels
{
  public class HallDetailsModel
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Rows { get; set; }
    [Required]
    public string NumberOfSeatsInRow { get; set; }
  }
}
