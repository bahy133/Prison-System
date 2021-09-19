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
    public partial class Form1 : Form
    {
        string str = "Data Source=DESKTOP-G8EMRH7\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string qry = "select count(*) from UserLogin where username ='" + textBox1.Text + "'and userPassword='" + textBox2.Text ;
            if (radioButton1.Checked == true)
            {
                qry += "'and userState='Officer'";
                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(qry, con);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    //this.Hide();
                    Form6 f6 = new Form6();
                    f6.Show();
                }
                else
                    MessageBox.Show("Error username/password please try again");
                con.Close();
            }
            else if (radioButton2.Checked == true)
            {
                qry += "'and userState='Admin'";
                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(qry, con);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    //this.Hide();
                    Form4 f4 = new Form4();
                    f4.Show();
                }
                else
                    MessageBox.Show("Error username/password please try again");
                con.Close();
            }
            else
                MessageBox.Show("Error, Please choose you are an officer or admin");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
