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
            // Перебираем ВСЕ элементы списка по индексам
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                Sportsmen sportsman = (Sportsmen)checkedListBox1.Items[i];

                // Проверяем, отмечен ли элемент
                bool isAttended = checkedListBox1.GetItemChecked(i);

                attendances = new Attendances
                {
                    CoachesId = (Coaches)comboBox1.SelectedItem,
                    SportsmenId = sportsman,
                    
                    TrainingDate = dateTimePicker1.Value.Date,
                    IsAttended = isAttended,  // true = присутствовал, false = прогулял
                };

                AddDataInBase.AddAttendances(attendances);
            }

            this.Close();
        }
    }
}