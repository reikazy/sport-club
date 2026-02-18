using sport_club.Models;
using sport_club.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sport_club.Forms
{
    public partial class AddCoaches : Form
        
    {
        public Coaches coaches;
        public AddCoaches()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            coaches = new Coaches()
            {
                FullName = textBox1.Text,
                SportType = textBox2.Text
            };
            AddDataInBase.AddCoaches(coaches);
            this.Close();
        }
    }
}
