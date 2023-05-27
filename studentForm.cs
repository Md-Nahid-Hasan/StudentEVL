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
    public partial class studentForm : Form
    {
        public studentForm()
        {
            InitializeComponent();
            fillCombobox1();
            fillCombobox2();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            LoginForm logPage = new LoginForm();
            logPage.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            homeForm home = new homeForm();
            home.Show();
            this.Hide();
        }

        SqlConnection con = new SqlConnection(@"Data Source=MDNAHIDHASAN;Initial Catalog=studentEVL;Integrated Security=True");
        private void save_Click(object sender, EventArgs e)
        {
            if (studentID.Text == "" || fName.Text == "" || lName.Text == "" || address.Text == "" || gender.Text == "" || department.Text =="" || course.Text == "" ) {
                MessageBox.Show("Please check your all any missing information");
            }
           
            else
            {
                try {
                    con.Open();
                    string query = "insert into stdTable values('" + studentID.Text + "','" + fName.Text + "','" + lName.Text + "','" + address.Text + "','" + gender.Text + "','" + department.Text + "','NULL','"+ course.Text +"')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data insert Successful!");
                    
                    con.Close();
                    populate();
                    dataClear();
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataClear()
        {
            studentID.Text = "";
            fName.Text = "";
            lName.Text = "";
            address.Text = "";
            gender.Text = "";
            department.Text = "";
            operand.Text = "";
        }
        private void populate()
        {
            con.Open();
            string query = "select * from stdTable";
            SqlDataAdapter sda = new SqlDataAdapter(query , con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridViewInsert.DataSource = ds.Tables[0];
            con.Close();
        }
        private void populateSearch()
        {
            
            con.Open();
            string query = "select * from stdTable where studentID = '" + searchBar.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridViewInsert.DataSource = ds.Tables[0];
            con.Close();
        }

        public void fillCombobox1()
        {
            con.Open();
            string show = "select courseNo from crcTable";
            SqlCommand cmd = new SqlCommand(show , con);
           
            SqlDataReader rdr;
                try
            {
                
                rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    string dlist = rdr.GetString(0);
                    course.Items.Add(dlist);
                    
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void fillCombobox2()
        {
            con.Open();
            string show = "select department from dptTable";
            SqlCommand cmd = new SqlCommand(show, con);

            SqlDataReader rdr;
            try
            {

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string dlist = rdr.GetString(0);
                    department.Items.Add(dlist);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void studentForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void dataGridViewInsert_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Mid = int.Parse(dataGridViewInsert.CurrentRow.Cells[0].Value.ToString());
            operand.Text = dataGridViewInsert.CurrentRow.Cells[0].Value.ToString();
            studentID.Text = dataGridViewInsert.CurrentRow.Cells[0].Value.ToString();
            fName.Text = dataGridViewInsert.CurrentRow.Cells[1].Value.ToString();
            lName.Text = dataGridViewInsert.CurrentRow.Cells[2].Value.ToString();
            address.Text = dataGridViewInsert.CurrentRow.Cells[3].Value.ToString();
            gender.Text = dataGridViewInsert.CurrentRow.Cells[4].Value.ToString();
            department.Text = dataGridViewInsert.CurrentRow.Cells[5].Value.ToString();
            course.Text = dataGridViewInsert.CurrentRow.Cells[7].Value.ToString();
        }

        private void edit_Click(object sender, EventArgs e)
        {
             
            con.Open();
            string query = "update stdTable set studentID = '"+ studentID.Text +"', first_name ='"+ fName.Text +"' ,last_name ='"+ lName.Text +"' , address ='"+ address.Text +"' ,gender ='"+ gender.Text +"' ,department = '"+ department.Text + "',courseNo = '" + course.Text + "' where studentID = '" + operand.Text +"'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has been updated!");
            populate();
            dataClear(); 
        }

        private void search_Click(object sender, EventArgs e)
        {
            populateSearch();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "delete stdTable where studentID = '" + studentID.Text + "'";
            SqlCommand cmd = new SqlCommand(query , con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has been deleted!");
            populate();
            dataClear();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            dataClear();
        }

        private void lName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
