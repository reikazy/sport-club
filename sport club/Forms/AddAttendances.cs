using sport_club.Models;
using sport_club.Services;
using System;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sport_club.Forms
{
    public partial class AddAttendances : Form
    {
        public Attendances attendances;

        public AddAttendances()
        {
            InitializeComponent();
      
            comboBox1.Items.AddRange(SportClubDatabase.GetCoaches().ToArray());

     
            
            checkedListBox1.Items.AddRange(SportClubDatabase.GetSportsmens().ToArray());
            

            dateTimePicker1.Value = DateTime.Now;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            

            foreach (Sportsmen sportsman in checkedListBox1.CheckedItems)
            {
                attendances = new Attendances
                {
                    SportsmenId = Attendances.GetSportsmen(sportsman.Id),        
                    CoachesId = Attendances.GetCoaches(comboBox1.SelectedIndex),     
                    TrainingDate = dateTimePicker1.Value.Date,
                    IsAttended = checkedListBox1.SelectedIndex,
                };

                
                AddDataInBase.AddAttendances(attendances);

            }
            


            this.Close();
        }
    }
}