using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Domain.Movies
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public ICollection<MovieGenre> Genre { get; set; }
        public ICollection<CrewMember> CrewMembers { get; set; }
        public TimeSpan PlayTime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte[] Photo { get; set; }
    }
}
