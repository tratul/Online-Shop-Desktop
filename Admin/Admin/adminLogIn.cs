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
    public partial class adminLogIn : Form
    {
        private static string conString = "Data Source=DESKTOP-ARCJRDG\\SUPTO_DB;Initial Catalog=projectDB;Integrated Security=True";
        public adminLogIn()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            try{
                SqlConnection conn = new SqlConnection(conString); //connection to database
            
                string query = "select * from AdminInfo where AdminUserName=@user and Password=@pw";
                SqlCommand com = new SqlCommand(query, conn);
                conn.Open();
                com.Parameters.AddWithValue("@user", textBox1.Text);
                com.Parameters.AddWithValue("@pw", textBox2.Text);
                SqlDataReader Dr = com.ExecuteReader();

                if (Dr.HasRows == true)
                {
                    Admin_panel ap = new Admin_panel();
                    this.Hide();
                    ap.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect User Name or Password !!! ");
                }
                
            }
            catch (SqlException sq)
            { 
                Console.WriteLine(sq);
                
            }
            
        }
    }
}
