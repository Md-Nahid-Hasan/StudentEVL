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
    public partial class dptFaculty : Form
    {
        public dptFaculty()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=MDNAHIDHASAN;Initial Catalog=studentEVL;Integrated Security=True");
        private void save_Click(object sender, EventArgs e)
        {
            if (dptId.Text == "" || department.Text == "")
            {
                MessageBox.Show("Missing any information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into dptTable values('" + dptId.Text + "','" + department.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("data inserted!");
                    dptId.Text = "";
                    department.Text = "";
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void populate()
        {
            con.Open();
            string query = "select * from dptTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridViewdept.DataSource = ds.Tables[0];
            con.Close();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            dptId.Text = "";
            department.Text = "";
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dptId.Text == "")
            {
                MessageBox.Show("please select data from list ");
            }
            else
            {
                con.Open();
                string query = "delete dptTable where departmentId = '" + dptId.Text.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("data has been deleted!");
                dptId.Text = "";
                department.Text = "";
                populate();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new facultydashboard().Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void dptFaculty_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void dataGridViewdept_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dptId.Text = dataGridViewdept.CurrentRow.Cells[0].Value.ToString();
            department.Text = dataGridViewdept.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
