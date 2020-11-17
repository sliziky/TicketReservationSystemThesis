using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketReservationSystem.Client.FormModels
{
  public class MovieDetailsModel
  {
    [JsonPropertyName("genres")]
    public List<Genre> Genres{ get; set; }

    public int Id { get; set; }

    [JsonPropertyName("original_language")]
    public string OriginalLanguage { get; set; }

    [JsonPropertyName("overview")]
    public string Overview { get; set; }

    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; }

    [JsonPropertyName("poster_path")]
    public string ImagePath { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }
    public class Genre {
      public int Id { get; set; }
      public string Name { get; set; }
    }
  }
}
