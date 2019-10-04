using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMediaProject.Models.Serie
{
    public class SeasonViewModel
    {
        public int Id { get; set; }
        public int SeasonNumber { get; set; }
        public int Episodes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
