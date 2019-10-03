using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMediaProject.Models.Movies;

namespace TheMediaProject.Models.Serie
{
    public class SeriesViewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte[] Photo { get; set; }
        public List<MovieGenreViewModel> Genre { get; set; }
        public List<MovieArtistListViewModel> Actors { get; set; }
        public List<MovieArtistListViewModel> Directors { get; set; }
        public string GenreString { get; set; }
        public string ActorsString { get; set; }
        public string DirectorsString { get; set; }
        public List<MovieGenreViewModel> GenreNames { get; set; }
        public List<MovieArtistListViewModel> CrewMemberNames { get; set; }
    }
}
