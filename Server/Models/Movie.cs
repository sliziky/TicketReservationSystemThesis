using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.Models
{
    public class Movie
    {
        // PK 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public bool Subtitles { get; set; }
        public string SubtitlesLanguage { get; set; }
        public DateTime Length { get; set; }
        public DateTime Released { get; set; }
        public List<MovieShow> Shows { get; set; }
        

    }
}
