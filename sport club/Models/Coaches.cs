using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace sport_club.Models
{
    public class Coaches
    {
        [Browsable(false)]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string SportType { get; set; }
        public override string ToString()
        {
            return $"{FullName} {SportType}";  
        }
    }
}
