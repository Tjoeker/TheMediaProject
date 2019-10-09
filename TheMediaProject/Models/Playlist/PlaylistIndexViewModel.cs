using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Models.Playlist
{
    public class PlaylistIndexViewModel
    {
        public List<string> Titles { get; set; } = new List<string>();
        public string Title { get; set; }
    }
}
