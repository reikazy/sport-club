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
    public partial class AddSportsmen : Form
    {
        public Sportsmen sportsmen;
        public AddSportsmen()
        {
            InitializeComponent();
        }
        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;

            var digits = new string(phone.Where(char.IsDigit).ToArray());
            return digits.Length == 10 || (digits.Length == 11 && (digits.StartsWith("7") || digits.StartsWith("8")));
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (sportsmen != null)
            {
                if (!IsValidPhone(maskedTextBox1.Text))
                {

                    sportsmen = new Sportsmen()
                    {
                        FullName = textBox1.Text,
                        Birthday = dateTimePicker1.Value.Date,
                        ParentPhone = maskedTextBox1.Text,

                    };
                    AddDataInBase.AddSportsmen(sportsmen);
                    this.Close();
                }
            }
                
        }
    }
}
