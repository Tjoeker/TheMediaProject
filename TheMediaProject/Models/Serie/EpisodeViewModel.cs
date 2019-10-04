﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Models.Serie
{
    public class EpisodeViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan PlayTime { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
