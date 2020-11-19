using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Client.FormModels
{
  public class ShowDetailsModel
  {
    [Required]
    public DateTime? ShowDate;

    [Required]
    public TimeSpan? StartTime;
    [Required]
    public TimeSpan? EndTime;
  }
}
