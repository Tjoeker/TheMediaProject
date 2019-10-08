using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TheMediaProject.Models.Movies;

namespace TheMediaProject.Models.Serie
{
    public class SeriesCreateViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Actors { get; set; }
        public string Directors { get; set; }
        public IFormFile Photo { get; set; }
        public List<MovieArtistListViewModel> artistNames { get; set; }
        public List<MovieGenreViewModel> genreNames { get; set; }
        public List<EpisodeCreateViewModel> Episodes { get; set; } = new List<EpisodeCreateViewModel>();
    }
}
