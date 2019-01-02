using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    public partial class Admin_panel : Form
    {
        public Admin_panel()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ad_showItem ad = new Ad_showItem();
            ad.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ad_quantity ad = new ad_quantity();
            ad.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            adminLogIn lg = new adminLogIn();
            this.Close();
            lg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Order sho = new Order();
            sho.Show();
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminSignUp ads =new AdminSignUp();
            this.Hide();
            ads.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AdminSignUp ads = new AdminSignUp();
            this.Hide();
            ads.Show();
        }
    }
}
