using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace TicketReservationSystem.Shared.Domain
{
  public class Cinema
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int CinemaId { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("city")]
    [Required]
    public string City { get; set; }

    [JsonPropertyName("halls")]
    [Required]
    public List<Hall> Halls { get; set; } = new List<Hall>();
  }
}
