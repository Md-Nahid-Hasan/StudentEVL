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
    public partial class homeForm : Form
    {
        public homeForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoginForm logpage = new LoginForm();
            logpage.Show();
            this.Hide();
        }

        private void student_Click(object sender, EventArgs e)
        {
            studentForm std = new studentForm();
            std.Show();
            this.Hide();
        }

        private void grades_Click(object sender, EventArgs e)
        {
            gradesForm grd = new gradesForm();
            grd.Show();
            this.Hide();
        }

        private void department_Click(object sender, EventArgs e)
        {
            departmentForm dpt = new departmentForm();
            dpt.Show();
            this.Hide();
        }

        private void curriculumn_Click(object sender, EventArgs e)
        {
            curriculumnForm crclmn = new curriculumnForm();
            crclmn.Show();
            this.Hide();
        }

        private void makeuser_Click(object sender, EventArgs e)
        {
            manageUserForm mng = new manageUserForm();
            mng.Show();
            this.Hide();
        }

        private void preRequisite_Click(object sender, EventArgs e)
        {
            preRequiredForm prq = new preRequiredForm();
            prq.Show();
            this.Hide();
        }
    }
}
