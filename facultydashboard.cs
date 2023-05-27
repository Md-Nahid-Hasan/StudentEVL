using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentEVL
{
    public partial class facultydashboard : Form
    {
        public facultydashboard()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void student_Click(object sender, EventArgs e)
        {
            new stdFaculty().Show();
            this.Hide();
        }

        private void grades_Click(object sender, EventArgs e)
        {
            new grdFaculty().Show();
            this.Hide();
        }

        private void department_Click(object sender, EventArgs e)
        {
            new dptFaculty().Show();
            this.Hide();
        }

        private void curriculumn_Click(object sender, EventArgs e)
        {
            new crcFaculty().Show();
            this.Hide();
        }

        private void preRequisite_Click(object sender, EventArgs e)
        {
            new preFacultyForm().Show();
            this.Hide();
        }

        private void makeuser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are not admin!","Access Failed",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
