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
    public partial class Form2 : Form
    {
        string str = "Data Source=DESKTOP-G8EMRH7\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ADD
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string qry = "select count(*) from officerInfo where officer_ID = "+ID.Text+"";
            SqlDataAdapter ad = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
                MessageBox.Show("ID already Exists, Choose another one");
            else
            {
                //putting prison id on the data table:
                string q = "select prison_ID from prisonInfo where prison_name='" + prison.Text + "'";
                SqlCommand c = new SqlCommand(q, con);
                c.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(c);
                DataTable tab = new DataTable();
                adapter.Fill(tab);
               
                //to check if username exists before
                SqlDataAdapter ad1 = new SqlDataAdapter("select count(*)from UserLogin where username='"+username.Text+"'", con);
                DataTable dt1 = new DataTable();
                ad1.Fill(dt1);
                if (dt1.Rows[0][0].ToString() == "1")
                    MessageBox.Show("Username already Exists, Choose another one");
                else
                {
                    //check law da5ali 2sm l prison 8lat :)
                    string qry2 = "select count(*) from prisonInfo where prison_name = '" + prison.Text + "'";
                    SqlDataAdapter ad2 = new SqlDataAdapter(qry2, con);
                    DataTable dt2 = new DataTable();
                    ad2.Fill(dt2);
                    if (dt2.Rows[0][0].ToString() == "1")
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        if (male.Checked)
                            cmd.CommandText = "insert into officerInfo values(" + ID.Text + ", '" + name.Text + "', '" + tele.Text + "', '" + address.Text + "', 'male', '" + duty.Text + "','"+tab.Rows[0][0]+"')";
                        else if (female.Checked)
                            cmd.CommandText = "insert into officerInfo values(" + ID.Text + ", '" + name.Text + "', '" + tele.Text + "', '" + address.Text + "', 'female', '" + duty.Text + "','"+ tab.Rows[0][0] + "')";
                        else
                            MessageBox.Show("Please choose gender");
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "insert into UserLogin values('" + username.Text + "', '" + pass.Text + "', 'officer'," + ID.Text + ")";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data is added successfully!");
                    }
                    else
                        MessageBox.Show("Invalid prison name,Please enter correct name");
                }
            }
            con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //delete
            this.Hide();
            Form8 f8 = new Form8();
            f8.Show();
            
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
