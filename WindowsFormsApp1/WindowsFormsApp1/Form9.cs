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
    public partial class Form9 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G8EMRH7\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
        
        public Form9()
        {
            InitializeComponent();
        }
     
   
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select prison_name from prisonInfo where prison_name='" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select count(*) from prisonInfo where prison_name = '" + textBox2.Text + "'";
            SqlDataAdapter ad = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                qry = "delete from prisonInfo where prison_name='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("data is deleted");
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowindex);
                textBox2.Clear();
            }
            else
                MessageBox.Show("Please Enter right data to delete");
            con.Close();

        }
    }
    }
