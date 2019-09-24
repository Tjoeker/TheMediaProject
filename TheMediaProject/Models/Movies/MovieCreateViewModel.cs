using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TheMediaProject.Domain.Movies;

namespace TheMediaProject.Models.Movies
{
    public class MovieCreateViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Genre { get; set; }
        public string Actors { get; set; }
        public string Directors { get; set; }
        public int PlayTimeHours { get; set; }
        public int PlayTimeMinutes { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte[] Photo { get; set; }
        public List<MovieArtistListViewModel> artistNames { get; set; }
    }
}
