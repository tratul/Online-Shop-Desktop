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
    public partial class ad_quantity : Form
    {
        private static string conString = "Data Source=DESKTOP-ARCJRDG\\SUPTO_DB;Initial Catalog=projectDB;Integrated Security=True";
        public ad_quantity()
        {
            InitializeComponent();
        }

        private void ad_quantity_Load(object sender, EventArgs e)
        {
           //load_data();
           this.stockTableTableAdapter.Fill(this.projectDBDataSet1.StockTable);
        }
        public void load_data()
        {
            //this.stockTableTableAdapter.Fill(this.projectDBDataSet1.StockTable);
        }


        private void confirm_btn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            string query1 = "update StockTable set Quantity ='"+Convert.ToInt32(numericUpDown1.Value)+"'where ItemId = '"+textBox1.Text+"'";
            SqlCommand cmd = new SqlCommand(query1,conn);
            cmd.ExecuteNonQuery();
            ad_quantity_Load(sender,e);

            //try
           /* {
                SqlConnection conn = new SqlConnection(conString);
                string query="select Count(*) from StockTable where ItemId='"+textBox1.Text+"'";
                SqlDataAdapter sa = new SqlDataAdapter(query,conn);
                DataTable dt = new DataTable();
                sa.Fill(dt);
                if (dt.Rows[0][0].ToString()== "1")
                {
                    MessageBox.Show("found ");
                    string query2 = "Update StockTable Set Quantity='" + int.Parse(textBox2.Text) + "'where ItemId='" + textBox1.Text + "'";
                    conn.Open();
                    SqlCommand cm = new SqlCommand(query2,conn);
                    cm.ExecuteNonQuery();
                }
                else 
                {
                    MessageBox.Show("not found ");
                }
            }
            catch (SqlException sq)
            {
                Console.WriteLine(sq);

            }
                */
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
            
                if (e.RowIndex >= 0)
            {
                
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                 numericUpDown1.Value = Convert.ToDecimal(row.Cells[3].Value);

            }
        
               
            

            
        }

        private void selection(object sender, EventArgs e)
        {
            
        }
    }
}
