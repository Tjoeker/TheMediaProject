using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMediaProject.Models.Movies;

namespace TheMediaProject.Models.Playlist
{
    public class PlaylistDetailViewModel
    {
        public string Title { get; set; }
        public int PlaylistId { get; set; }
        public List<MovieViewViewModel> Movies { get; set; } = new List<MovieViewViewModel>();
    }
}
