using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_club.Models
{
    public class ChildActivity
    {
        [Browsable(false)]
        public int SportsmanId { get; set; }
        public string SportsmanName { get; set; } 
        public DateTime? Birthday { get; set; }
        public int Age { get; set; }
        public int TotalTrainings { get; set; }
        public int AttendedCount { get; set; }
        public int SkippedCount { get; set; }
        public double? AttendancePercentage { get; set; }
    }
}
