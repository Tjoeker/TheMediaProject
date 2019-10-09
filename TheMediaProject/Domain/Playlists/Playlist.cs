using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Domain.Playlists
{
    public class Playlist
    {
        public string UserId { get; set; }
        public int PlaylistId { get; set; }
        public string Title { get; set; }
    }
}
