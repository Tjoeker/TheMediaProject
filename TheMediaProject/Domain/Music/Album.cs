using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Domain.Music
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Artist AlbumArtist { get; set; }
        public ICollection<Song> Songs { get; set; }
        public byte[] AlbumArt { get; set; }
        public int GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
