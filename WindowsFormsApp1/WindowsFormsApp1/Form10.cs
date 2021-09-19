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
    public partial class Form10 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G8EMRH7\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
        public Form10()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select count(*) from prisonerInfo where prisoner_ID = " + textBox1.Text + "";
            SqlDataAdapter ad1 = new SqlDataAdapter(qry, con);
            DataTable dt1 = new DataTable();
            ad1.Fill(dt1);
            if (dt1.Rows[0][0].ToString() == "1")
                MessageBox.Show("ID already Exists, Choose another one");
            else
            {
                string qry2 = "select count(*) from prisonInfo where prison_name = '" + textBox7.Text + "'";
                SqlDataAdapter ad2 = new SqlDataAdapter(qry2, con);
                DataTable dt2 = new DataTable();
                ad2.Fill(dt2);
                if (dt2.Rows[0][0].ToString() == "1")
                {

                    string qry1 = "select prison_ID from prisonInfo where prison_name='" + textBox7.Text + "'";
                    SqlCommand cmd = new SqlCommand(qry1, con);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                   DataTable dt = new DataTable();
                    da.Fill(dt);

                    qry = "insert into prisonerInfo values('" + Convert.ToInt32(textBox1.Text) + "','" + textBox2.Text + "','" + Convert.ToInt32(textBox3.Text) + "','" + textBox4.Text + "','" + Convert.ToInt32(textBox5.Text) + "','" + dt.Rows[0][0] + "','" + Convert.ToInt32(textBox6.Text) + "','"+textBox9.Text+"')";
                    SqlCommand cmd1 = new SqlCommand(qry, con);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Data added");
                }
                else
                    MessageBox.Show("Invalid prison name,Please enter correct name");
            }
            con.Close();

        }
    }
}
