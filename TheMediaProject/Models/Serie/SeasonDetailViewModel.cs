using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Models.Serie
{
    public class SeasonDetailViewModel
    {
        public string SeriesTitle { get; set; }
        public int SeasonId { get; set; }
        public int SeriesId { get; set; }
        public int SeasonNumber { get; set; }
        public List<EpisodeViewModel> Episodes { get; set; } 
        public List<SeasonViewModel> Seasons { get; set; } = new List<SeasonViewModel>();
        public byte[] Photo { get; set; }
    }
}
