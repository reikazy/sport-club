using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_club.Models
{
    public class Sportsmen
    {
        [Browsable(false)]
        public int Id { get; set; }

        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string ParentPhone { get; set; }
        public override string ToString()
        {
            return $"{FullName}";
        }
    }
}
