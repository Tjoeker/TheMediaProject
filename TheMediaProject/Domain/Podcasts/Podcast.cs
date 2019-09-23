using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Domain.Podcasts
{
    public class Podcast
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<PodcastPerson> PodcastPeople { get; set; }
        public PodcastGenre Genre { get; set; }
        public PodcastFormat Format { get; set; }
        public byte[] Photo { get; set; }
    }
}
