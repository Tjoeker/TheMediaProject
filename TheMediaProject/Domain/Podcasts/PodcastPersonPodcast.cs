using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Domain.Podcasts
{
    public class PodcastPersonPodcast
    {
        public int PodcastId { get; set; }
        public int PodcastPersonId { get; set; }
        public enum Role { Host, Guest };
        public Role PersonRole { get; set; }
    }
}
