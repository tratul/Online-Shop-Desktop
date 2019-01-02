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
namespace Admin
{
    public partial class AdminSignUp : Form
    {
        private static string conString = "Data Source=DESKTOP-ARCJRDG\\SUPTO_DB;Initial Catalog=projectDB;Integrated Security=True";
        public AdminSignUp()
        {
            InitializeComponent();
        }

        private void button_signUP_Click(object sender, EventArgs e)
        {
            if (textBox_fullName.Text != "" && textBox_userName.Text != "" && textBox_pass.Text != "" && textBox_confirmPass.Text != "")
            {
                if (label6.Visible == true)
                {
                    label6.Visible = false;
                }
                if (textBox_email.Text.Contains("@") && textBox_email.Text.Contains(".com"))
                {

                    if (textBox_fullName.Text != null && textBox_userName.Text != null && textBox_email.Text != null && textBox_pass.Text != null && textBox_confirmPass.Text != null)
                    {
                        if (textBox_pass.Text.Equals(textBox_confirmPass.Text))
                        {
                            SqlConnection conn = new SqlConnection(conString); //connection to database
                            string query = "insert into AdminInfo (AdminUserName,Password,Email,FullName) values('" + textBox_userName.Text + "','" + textBox_pass.Text + "','" + textBox_email.Text + "','" + textBox_fullName.Text + "')";
                            SqlCommand com = new SqlCommand(query, conn);
                            conn.Open();

                            SqlDataReader Dr = com.ExecuteReader();
                            MessageBox.Show("NEW ADMIN ADDED !!!");
                            Admin_panel ap = new Admin_panel();
                            this.Hide();
                            ap.Show();
                        }
                        else
                        {
                            MessageBox.Show("Password didn't match");
                            textBox_pass.Text = null;
                            textBox_confirmPass.Text = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter all required DATA !!!");
                    }
                }
            }
            else 
            {
                label6.Visible = true;
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_panel ap = new Admin_panel();
            this.Hide();
            ap.Show();
        }
    }
}
