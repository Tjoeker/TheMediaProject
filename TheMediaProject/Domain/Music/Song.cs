using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Domain.Music
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Track { get; set; }
        public int Disc { get; set; }
        public TimeSpan Length { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
