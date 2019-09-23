using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Models.Movie
{
    public class MovieIndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Photo { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan PlayTime { get; set; }
        public string Genre { get; set; }
    }
}
