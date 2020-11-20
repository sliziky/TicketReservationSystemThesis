using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Client.FormModels
{
  public class SeatPickerModel
  {
    public int Adults { get; set; } = 0;
    public int Kids { get; set; } = 0;
    public int Seniors { get; set; } = 0;
    public int Students { get; set; } = 0;
  }
}
