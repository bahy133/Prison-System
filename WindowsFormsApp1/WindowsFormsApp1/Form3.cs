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
    public partial class Form3 : Form
    {
        string str = "Data Source=DESKTOP-G8EMRH7\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string qry = "select count(*) from prisonInfo where prison_ID = " + ID.Text + "";
            SqlDataAdapter ad = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
                MessageBox.Show("ID already Exists, Choose another one");
            else
            {
                SqlCommand cmd = new SqlCommand("insert into prisonInfo values(" + ID.Text + ", '" + name.Text + "', '" + place.Text + "', " + capacity.Text + ",'"+Convert.ToInt32(textBox1.Text)+"')", con);
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "insert into prisonInfo values(" + ID.Text + ", '" + name.Text + "', '" + place.Text + "', " + capacity.Text + ")";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data is added successfully!");
            }
            con.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delete
            this.Hide();
            Form9 f9 = new Form9();
            f9.Show();
            
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}