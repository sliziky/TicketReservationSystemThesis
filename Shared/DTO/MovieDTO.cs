using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Shared.DTO
{
    public class MovieDTO
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public string ImageUrl { get; set; }
        public bool Subtitles { get; set; }
        public string SubtitlesLanguage { get; set; }
        public string Length { get; set; }
        public DateTime? Released { get; set; }
        public List<MovieShow> Shows { get; set; }
    }
}
