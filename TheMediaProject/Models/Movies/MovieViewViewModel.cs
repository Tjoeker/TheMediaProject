using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Models.Movies
{
    public class MovieViewViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan PlayTime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte[] Photo { get; set; }
        public List<MovieGenreViewModel> Genre { get; set; }
        public List<MovieArtistListViewModel> Actors { get; set; }
        public List<MovieArtistListViewModel> Directors { get; set; }
    }
}
