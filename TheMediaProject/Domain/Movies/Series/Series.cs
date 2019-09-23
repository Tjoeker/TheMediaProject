using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Domain.Movies.Series
{
    public class Series
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<CrewMember> CrewMembers { get; set; }
        public ICollection<Season> Seasons { get; set; }
        public byte[] Photo { get; set; }
    }
}
