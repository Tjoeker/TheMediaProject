using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Domain.Movie
{
    public class MovieCrewMember
    {
        public int MovieId { get; set; }
        public int CrewMemberId { get; set; }
        public enum Role { Actor, Director};
        public Role MemberRole { get; set; }
    }
}
