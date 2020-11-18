using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Client.FormModels
{
  public class HallDetailsModel
  {
    [Required(ErrorMessage = "Name of the hall is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Number of rows is required")]
    [Range(0, int.MaxValue, ErrorMessage = "Please enter number")]
    public string Rows { get; set; }

    [Required(ErrorMessage = "Number of seats in 1 row is required")]
    [Range(0, int.MaxValue, ErrorMessage = "Please enter number")]
    public string NumberOfSeatsInRow { get; set; }
  }
}
