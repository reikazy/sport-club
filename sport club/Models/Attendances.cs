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
        public List<Sportsmen> SportsmenId { get; set; }
        [Browsable(false)]
        public Coaches CoachesId { get; set; }
        public string DisplaySportsmenId => string.Join(", ", SportsmenId.Select(s => s.Id).ToList());
        public int DisplayCoachesId => CoachesId.Id;
        public DateTime TrainingDate { get; set; }
        public bool IsAttended { get; set; }


        public static List<Sportsmen> GetSportsmen(string sportsmensId)
        {
            List<Sportsmen> sportsmenForOrder = new();
            List<Sportsmen> sportsmens = SportClubDatabase.GetSportsmens();
            int[] disesIdInt = sportsmensId.Split(',').Select(d => Int32.Parse(d)).ToArray();
            sportsmenForOrder = sportsmens.Where(d => disesIdInt.Contains(d.Id)).ToList();
            return sportsmenForOrder;
        }
        public static Coaches GetCoaches(int id)
        {
            Coaches Coaches = new();
            List<Coaches> coach = SportClubDatabase.GetCoaches();
            return coach.Find(c => c.Id == id);
        }
    }
}
