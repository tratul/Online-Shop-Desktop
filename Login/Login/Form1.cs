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

namespace Login
{
    public partial class Form1 : Form
    {
        Form2 fm2;
        public Form1()
        {
            InitializeComponent();
        }
        private static string conString = "Data Source=DESKTOP-ARCJRDG\\SUPTO_DB;Initial Catalog=projectDB;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("0");


            try
            {
               
                SqlConnection conn = new SqlConnection(conString);
                MessageBox.Show("2,1");
                string query = "select * from login_info where UserName=@user and Password=@pw" ;
                SqlCommand com = new SqlCommand(query,conn);
                conn.Open();
                com.Parameters.AddWithValue("@user",textBox1.Text);
                com.Parameters.AddWithValue("@pw",textBox2.Text);
                SqlDataReader Dr = com.ExecuteReader();

                if(Dr.HasRows == true)
                {
                    Form2 fm = new Form2();
                    this.Hide();
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect User Name or Password");
                }
            }
                
            
            catch (SqlException sq) 
                { Console.WriteLine(sq); }
            
            }
    }
}
