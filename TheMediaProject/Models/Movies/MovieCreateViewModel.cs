﻿using Microsoft.AspNetCore.Http;
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
        public string Genre { get; set; }
        public string Actors { get; set; }
        public string Directors { get; set; }
        public int PlayTimeHours { get; set; }
        public int PlayTimeMinutes { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public IFormFile Photo { get; set; }
        public List<MovieArtistListViewModel> artistNames { get; set; }
        public List<MovieGenreViewModel> genreNames { get; set; }
    }
}
