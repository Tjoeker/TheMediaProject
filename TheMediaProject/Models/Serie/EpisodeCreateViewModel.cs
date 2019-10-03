using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Models.Serie
{
    public class EpisodeCreateViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PlayTimeHours { get; set; }
        public int PlayTimeMinutes { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
