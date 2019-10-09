using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Domain.Playlists
{
    public class PlaylistItem
    {
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public int MediaId { get; set; }
        public enum MediaType { Movie, Series}
        public MediaType Type { get; set; }
    }
}
