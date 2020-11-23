using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Client.FormModels
{
  public class CinemaModel
  {
    [Required]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [Required]
    public string GatewayApiKey { get; set; }

    [Required]
    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("halls")]
    public List<Hall> Halls { get; set; } = new List<Hall>();
  }
}
