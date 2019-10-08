using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Models.Serie
{
    public class AddSeasonViewModel
    {
        public int SeriesId { get; set; }
        public EpisodeCreateViewModel Episode { get; set; }
    }
}
