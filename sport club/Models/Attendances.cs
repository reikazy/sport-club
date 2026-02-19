using sport_club.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_club.Models

{
    public class Attendances
    {
        [Browsable(false)]
        public  int Id { get; set; }
        [Browsable(false)]
        public Sportsmen SportsmenId { get; set; }
        [Browsable(false)]
        public Coaches CoachesId { get; set; }
        public int DisplaySportsmenId => SportsmenId.Id;
        public int DisplayCoachesId => CoachesId.Id;
        public DateTime TrainingDate { get; set; }
        public bool IsAttended { get; set; }


        public static Sportsmen GetSportsmen(int id)
        {
            Sportsmen Coaches = new();
            List<Sportsmen> coach = SportClubDatabase.GetSportsmens();
            return coach.Find(c => c.Id == id);
        }
        public static Coaches GetCoaches(int id)
        {
            Coaches Coaches = new();
            List<Coaches> coach = SportClubDatabase.GetCoaches();
            return coach.Find(c => c.Id == id);
        }
    }
}
