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
    public partial class manageUserForm : Form
    {
        public manageUserForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            LoginForm log = new LoginForm();
            log.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            homeForm hom = new homeForm();
            hom.Show();
            this.Hide();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            dataClear();
        }
        private void dataClear()
        {
            userID.Text = "";
            username.Text = "";
            passworduser.Text = "";
            usertype.Text = "";
        }
        private void populate()
        {
            con.Open();
            string query = "select * from userTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridViewUser.DataSource = ds.Tables[0];
            con.Close();
        }
        SqlConnection con = new SqlConnection(@"Data Source=MDNAHIDHASAN;Initial Catalog=studentEVL;Integrated Security=True");
        private void save_Click(object sender, EventArgs e)
        {
            if(userID.Text=="" || username.Text=="" || passworduser.Text=="" || usertype.Text == "")
            {
                MessageBox.Show("Missing any information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into userTable values('"+ userID.Text + "','" + username.Text + "','" + passworduser.Text + "','" + usertype.Text + "')";
                    SqlCommand cmd = new SqlCommand(query , con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("new user created");
                    dataClear();
                    populate();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void manageUserForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (userID.Text == "")
            {
                MessageBox.Show("Please select data for delete!");
            }
            else
            {
                con.Open();
                string query = "delete userTable where Id = '"+ userID.Text +"'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("User deleted!");
                populate();
                dataClear();
            }
        }

        private void dataGridViewUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            userID.Text = dataGridViewUser.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
