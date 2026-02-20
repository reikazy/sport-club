using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_club.Models
{
    public class SkipperReport
    {
        [Browsable(false)]
        public int SportsmanId { get; set; }
        public string SportsmanName { get; set; } 
        public DateTime? Birthday { get; set; }
        public string ParentPhone { get; set; } 
        public DateTime TrainingDate { get; set; }
        public string CoachName { get; set; } 
        public string SportType { get; set; } 

    }
}
