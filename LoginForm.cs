using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentEVL
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            if(username.Text == "admin" && password.Text == "admin")
            {
                homeForm home = new homeForm();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=MDNAHIDHASAN;Initial Catalog=studentEVL;Integrated Security=True");
        private void facultyLog_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = "select * from userTable where userName= '" + username.Text + "' and password = '" + password.Text + "'";
            SqlCommand cmd = new SqlCommand(login , con);
            SqlDataReader dr = cmd.ExecuteReader();
            

            if(dr.Read() == true)
            {
                MessageBox.Show("Logged as a faculty","Faculty Login",MessageBoxButtons.OK,MessageBoxIcon.Information);
                new facultydashboard().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Login Failed" , MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
