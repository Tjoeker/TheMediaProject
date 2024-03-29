﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Domain.Movies.Serie
{
    public class Episode
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan PlayTime { get; set; }
        public int SeasonId { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
