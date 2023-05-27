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
    public partial class preFacultyForm : Form
    {
        public preFacultyForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new facultydashboard().Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=MDNAHIDHASAN;Initial Catalog=studentEVL;Integrated Security=True");
        private void save_Click(object sender, EventArgs e)
        {
            if (precourse.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update crcTable set precourse = '" + precourse.Text + "' where courseNo = '" + courseNo.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("sccessfully set pre-requisite course");
                    precourse.Text = "";
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
            string query = "select * from crcTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridViewCurrclmn.DataSource = ds.Tables[0];
            con.Close();
        }

        private void populateSearch()
        {

            con.Open();
            string query = "select * from crcTable where   courseNo ='" + searchBar.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridViewCurrclmn.DataSource = ds.Tables[0];
            con.Close();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            courseNo.Text = "";
            CourseTitle.Text = "";
            semester.Text = "";
        }

        private void search_Click(object sender, EventArgs e)
        {
            populateSearch();
            courseNo.Text = "";
            CourseTitle.Text = "";
            semester.Text = "";
            precourse.Text = "";
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            populate();
            courseNo.Text = "";
            CourseTitle.Text = "";
            semester.Text = "";
            searchBar.Text = "";
        }

        private void preFacultyForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void dataGridViewCurrclmn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            courseNo.Text = dataGridViewCurrclmn.CurrentRow.Cells[1].Value.ToString();
            CourseTitle.Text = dataGridViewCurrclmn.CurrentRow.Cells[2].Value.ToString();
            semester.Text = dataGridViewCurrclmn.CurrentRow.Cells[4].Value.ToString();
            precourse.Text = dataGridViewCurrclmn.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
