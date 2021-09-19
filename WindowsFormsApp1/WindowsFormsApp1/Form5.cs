using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G8EMRH7\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
        public Form5()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select * from prisonerInfo where prisoner_PunshYears='" + textBox4.Text + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter daaa = new SqlDataAdapter(cmd);
            daaa.Fill(dt2);
            dataGridView1.DataSource = dt2;
            con.Close();
            textBox4.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            //to check if username exists before
            SqlDataAdapter ad1 = new SqlDataAdapter("select count(*)from prisonInfo where prison_name='" + textBox3.Text + "'", con);
            DataTable dt1 = new DataTable();
            ad1.Fill(dt1);
            if (dt1.Rows[0][0].ToString() == "1")
            {
                string qry = "select prison_ID from prisonInfo where prison_name='" + textBox3.Text + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                string qry1 = "select * from prisonerInfo where prisoner_prisonID='" + dt.Rows[0][0] + "'";
                SqlCommand cmd1 = new SqlCommand(qry1, con);
                cmd.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(dt2);
                dataGridView1.DataSource = dt2;
                con.Close();
                textBox3.Text = string.Empty;
            }
            else
                MessageBox.Show("Invalid prison name,Please enter correct name");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select * from prisonerInfo where prisoner_crime='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter daa = new SqlDataAdapter(cmd);
            daa.Fill(dt1);
            dataGridView1.DataSource = dt1;
            con.Close();
            textBox1.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select * from prisonerInfo where prisoner_cellNumb='" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter daaa = new SqlDataAdapter(cmd);
            daaa.Fill(dt2);
            dataGridView1.DataSource = dt2;
            con.Close();
            textBox2.Text = string.Empty;
        }
    }
}
