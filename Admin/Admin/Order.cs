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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        private static string conString = "Data Source=DESKTOP-ARCJRDG\\SUPTO_DB;Initial Catalog=projectDB;Integrated Security=True";
        private void Order_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDBDataSet6.showOrder_admin' table. You can move, or remove it, as needed.
            this.showOrder_adminTableAdapter.Fill(this.projectDBDataSet6.showOrder_admin);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                comboBox1.Text = row.Cells[4].Value.ToString();



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            string Query1 = "update showOrder_admin set status ='" + comboBox1.Text + "'where orderId='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(Query1, conn);
            cmd.ExecuteNonQuery();
            Order_Load(sender, e);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            string Query1 = "Delete from showOrder_admin Where orderId = '"+textBox1.Text+"'";
            string Query2 = "Delete from orderItem Where orderId = '" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(Query1, conn);
            SqlCommand cmd2 = new SqlCommand(Query2, conn);
           
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            Order_Load(sender, e);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void visible()
        {
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;

            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlConnection conn = new SqlConnection(conString);
                conn.Open();

                string Query1 = " select * from orderItem where orderId = '" + int.Parse(textBox1.Text) + "'";
                SqlDataReader dr = null;

                SqlCommand cmd = new SqlCommand(Query1, conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                textBox2.Text = dr["item1"].ToString();
                textBox3.Text = dr["item2"].ToString();
                textBox4.Text = dr["item3"].ToString();
                textBox5.Text = dr["item4"].ToString();

                textBox6.Text = dr["quantity1"].ToString();
                textBox7.Text = dr["quantity2"].ToString();
                textBox8.Text = dr["quantity3"].ToString();
                textBox9.Text = dr["quantity4"].ToString();




                visible();
            }
            else 
            {
                MessageBox.Show("Select a row first !!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_panel apa = new Admin_panel();
            this.Hide();
            apa.Show();
        }
    }
}
