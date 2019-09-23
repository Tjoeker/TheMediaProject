using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Models.Movies
{
    public class MovieListItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Photo { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan PlayTime { get; set; }
        public List<string> Genre { get; set; }
        public string Description { get; set; }
    }
}
