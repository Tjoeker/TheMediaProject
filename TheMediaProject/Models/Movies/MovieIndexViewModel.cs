﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Models.Movies
{
    public class MovieIndexViewModel
    {
        public List<MovieListItemViewModel> MovieListItems { get; set; } = new List<MovieListItemViewModel>();
    }
}
