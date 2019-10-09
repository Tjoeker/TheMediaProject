﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Models.Playlist
{
    public class PlaylistIndexViewModel
    {
        public List<PlaylistListViewModel> Playlists { get; set; } = new List<PlaylistListViewModel>();
        public string Title { get; set; }
    }
}
