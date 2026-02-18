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
            
            dataGridView2.DataSource = SportClubDatabase.GetCoachStatistics();
            dataGridView3.DataSource = SportClubDatabase.GetChildActivityReport();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = SportClubDatabase.GetSkippersReport( dateTimePicker1.Value, dateTimePicker2.Value);
        }
    }
}
