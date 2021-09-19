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
    public partial class Form7 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-G8EMRH7\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Please enter data to update");
            else
            {
                con.Open();
                string qry = "select count(*) from prisonerInfo where prisoner_ID = " + textBox1.Text + "";
                SqlDataAdapter ad = new SqlDataAdapter(qry, con);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    qry = "update prisonerInfo set prisoner_cellNumb='" + Convert.ToInt32(textBox2.Text) + "'where prisoner_ID='" + Convert.ToInt32(textBox1.Text) + "'";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cell is edited successfully!");
                }
                else
                    MessageBox.Show("ID doesn't exist, Please enter right ID");
                con.Close();
            }
        }
    }
}
