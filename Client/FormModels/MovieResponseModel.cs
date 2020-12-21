using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketReservationSystem.Client.FormModels
{
  public class MovieResponseModel
  {
    [JsonPropertyName("results")]
    public List<MovieModel> Results{ get; set; }
    public class MovieModel {
      [JsonPropertyName("adult")]
      public bool Adult { get; set; }

      [JsonPropertyName("backdrop_path")]
      public string BackdropPath { get; set; }
            [JsonPropertyName("id")]
            public int Id { get; set; }
      public string OriginalLanguage { get; set; }
      public string OriginalTitle { get; set; }

      [JsonPropertyName("overview")]
      public string Overview { get; set; }

      [JsonPropertyName("title")]
      public string Title { get; set; }
    }

  }


}
