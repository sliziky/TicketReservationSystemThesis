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

    [Required]
    public string GatewayApiKey { get; set; }

    [Required]
    public string GatewayApiSecretKey { get; set; }
        
    [Required]
    public string SendGridApiKey { get; set; }

    [Required]
    public string Name { get; set; }

     public bool IsObsolete { get; set; } = false;

    [Required]
    public string City { get; set; }

    [Required]
    public List<Hall> Halls { get; set; } = new List<Hall>();
  }
}
