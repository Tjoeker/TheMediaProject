using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Domain.Movie.Series
{
    public class Series
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<CrewMember> Actors { get; set; }
        public ICollection<CrewMember> Director { get; set; }
        public ICollection<Season> Seasons { get; set; }
    }
}
