using sport_club.Models;
using sport_club.Services;
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
            dataGridView1.DataSource = SportClubDatabase.GetSportsmens();
            dataGridView2.DataSource = SportClubDatabase.GetCoaches();
            dataGridView3.DataSource = SportClubDatabase.GetAttendances();
        }
    }
}
