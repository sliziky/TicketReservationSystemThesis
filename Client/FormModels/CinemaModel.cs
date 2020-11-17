using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Client.FormModels
{
  public class NewCinemaModel
  {
    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [Required]
    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("halls")]
    public List<Hall> halls { get; set; } = new List<Hall>();
  }
}
