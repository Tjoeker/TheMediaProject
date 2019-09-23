using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Domain.Movies.Series
{
    public class Season
    {
        public int Id { get; set; }
        public int SeasonNumber { get; set; }
        public ICollection<Episode> Episodes { get; set; }
        public int SeriesId { get; set; }
    }
}
