using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMediaProject.Models.Playlist;

namespace TheMediaProject.Models.Movies
{
    public class MovieViewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan PlayTime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte[] Photo { get; set; }
        public List<MovieGenreViewModel> Genre { get; set; }
        public List<MovieArtistListViewModel> Actors { get; set; }
        public List<MovieArtistListViewModel> Directors { get; set; }
        public List<PlaylistListViewModel> Playlists { get; set; }
        public string GenreString { get; set; }
        public string ActorsString { get; set; }
        public string DirectorsString { get; set; }
        public string PlaylistString { get; set; }
        public List<MovieGenreViewModel> GenreNames { get; set; }
        public List<MovieArtistListViewModel> CrewMemberNames { get; set; }
    }
}
