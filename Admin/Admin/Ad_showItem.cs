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
    public partial class Ad_showItem : Form
    {
        public Ad_showItem()
        {
            InitializeComponent();
        }

        private void Ad_showItem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDBDataSet.StockTable' table. You can move, or remove it, as needed.
            this.stockTableTableAdapter.Fill(this.projectDBDataSet.StockTable);

        }
    }
}
