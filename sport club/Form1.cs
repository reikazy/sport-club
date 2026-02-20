using sport_club.Models;
using sport_club.Services;
using sport_club.Forms;
using System.Windows.Forms.Design.Behavior;
namespace sport_club
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetData();
        }

        public void GetData()
        {
            dataGridView6.DataSource = SportClubDatabase.GetAttendances();
            dataGridView5.DataSource = SportClubDatabase.GetSportsmens();
            dataGridView4.DataSource = SportClubDatabase.GetCoaches();
            dataGridView2.DataSource = SportClubDatabase.GetCoachStatistics();
            dataGridView3.DataSource = SportClubDatabase.GetChildActivityReport();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = SportClubDatabase.GetSkippersReport(dateTimePicker1.Value, dateTimePicker2.Value);
        }





        private void button3_Click(object sender, EventArgs e)
        {
            AddCoaches addcoaches = new AddCoaches();
            addcoaches.FormClosing += AddCoaches_FormClosing;
            addcoaches.ShowDialog();

        }
        private void AddCoaches_FormClosing(object? sender, FormClosingEventArgs e)
        {
            List<Coaches>? coaches = dataGridView4.DataSource as List<Coaches>;
            coaches.Add(((AddCoaches)sender).coaches);
            dataGridView4.DataSource = null;
            dataGridView4.DataSource = coaches;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddSportsmen addsportsmen = new AddSportsmen();
            addsportsmen.FormClosing += AddSportsmen_FormClosing;
            addsportsmen.ShowDialog();

        }
        private void AddSportsmen_FormClosing(object? sender, FormClosingEventArgs e)
        {
            List<Sportsmen>? sportsmen = dataGridView5.DataSource as List<Sportsmen>;
            sportsmen.Add(((AddSportsmen)sender).sportsmen);
            dataGridView5.DataSource = null;
            dataGridView5.DataSource = sportsmen;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddAttendances addattendances = new AddAttendances();
            addattendances.FormClosing += AddAttendances_FormClosing;
            addattendances.ShowDialog();

        }
        private void AddAttendances_FormClosing(object? sender, FormClosingEventArgs e)
        {
            List<Attendances>? attendances = dataGridView6.DataSource as List<Attendances>;
            attendances.Add(((AddAttendances)sender).attendances);
            dataGridView6.DataSource = null;
            dataGridView6.DataSource = SportClubDatabase.GetAttendances();

        }
        private void mainView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    RowDelete(sender as DataGridView);
                    GetData();
                    break;
            }
        }
        private void RowDelete(DataGridView dataGrid)
        {
            int Rowindex = dataGrid.SelectedCells[0].RowIndex;
            var Row = dataGrid.Rows[Rowindex];
            var data = Row.DataBoundItem;

            if (data is Attendances attendances)
            {
                DeleteDataInBase.RemoveAttendance(attendances.Id);
                dataGrid.DataSource = SportClubDatabase.GetAttendances();
            }
            else if (data is Coaches coaches)
            {
                DeleteDataInBase.RemoveCoache(coaches.Id);
                dataGrid.DataSource = SportClubDatabase.GetCoaches();
            }
            else if (data is Sportsmen sportsmen)
            {
                DeleteDataInBase.RemoveSportsmen(sportsmen.Id);
                dataGrid.DataSource = SportClubDatabase.GetSportsmens();
            }


        }
        private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var dataGrid = (DataGridView)sender;
            int Rowindex = dataGrid.SelectedCells[0].RowIndex;
            var row = ((DataGridView)sender).Rows[Rowindex];
            var data = row.DataBoundItem;

            if (data is Coaches coaches)
            {
                UpdateDataInBase.Update(coaches);
                GetData();
            }
            else if (data is Sportsmen sportsmen)
            {
                UpdateDataInBase.Update(sportsmen);
                GetData();
            }
            else if (data is Attendances attendances)
            {
                UpdateDataInBase.Update(attendances);
                GetData();
            }


        }
    }
}

