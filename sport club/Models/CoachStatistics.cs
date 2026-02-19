using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_club.Models
{
    public class CoachStatistics
    {
        public int CoachId { get; set; }
        public string CoachName { get; set; } 
        public string SportType { get; set; } 
        public int TotalTrainings { get; set; }
        public int AttendedTrainings { get; set; }
        public int SkippedTrainings { get; set; }
        public double? AttendancePercentage { get; set; }
    }
}
