using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class ProceedForm : Form
    {
        string ret;
        string phn,bilAdd,tId;
        public ProceedForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AddressTxt.Text != "" && BillAddTxt.Text != "" && TransIdTxt.Text != "")
            {
                phn = AddressTxt.Text;
                bilAdd = BillAddTxt.Text;
                tId = TransIdTxt.Text;
                this.Hide();
            }
            else
                label6.Visible = true;
        }
        public string getInfo()
        {
            if (ret != "0")
            {
                return (phn + ";" + bilAdd + ";" + tId);

            }
            else
                return "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ret =  "0";
            this.Hide();
        }
    }
}
