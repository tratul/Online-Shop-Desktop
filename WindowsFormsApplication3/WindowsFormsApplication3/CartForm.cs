using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication3
{
    public partial class CartForm : Form
    {

        const int PORT_NO = 8080;
        const string SERVER_IP = "127.0.0.1";
        private static Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        

        public static Item it = new Item();
        Item[] items = new Item[4];
        int counter ;
        Shop sp = new Shop();
        ProceedForm pf = new ProceedForm();
        string proceedInfo;
        
        
        public CartForm()
        {
            
            InitializeComponent();
            it.ItemId = "0";
            it.ItemName = "";
            it.quantity = 0;
            it.price = 0;
            items[0] = it;
            items[1] = it;
            items[2] = it;
            items[3] = it;
            if (!client.Connected)
            {
                client.Connect(IPAddress.Parse(SERVER_IP), PORT_NO);
            }
            
        }
        private void send()
        {
            byte[] buffer;
            proceedInfo = pf.getInfo();
            if (proceedInfo != "0")
            {

                if (counter > 0)
                {
                    string tp = totalPrice.Text;
                    string order = "order;" + items[0].ItemId + "&" + items[0].quantity + ";" + items[1].ItemId + "&" + items[1].quantity + ";" + items[2].ItemId + "&" + items[2].quantity + ";" + items[3].ItemId + "&" + items[3].quantity + ";" + proceedInfo + ";" + counter + ";" + tp;
                    buffer = Encoding.ASCII.GetBytes(order);
                    client.Send(buffer);
                    MessageBox.Show("Order Has been Send.. Wait for confirmation CALL !!!! ");
                }
                else
                {
                    MessageBox.Show("PLACE AN ORDER !!!! ");
                }
            }
            else 
            {
                MessageBox.Show("CLICK PROCEED!!! AND ENTER INFORMATION ");
            }
        }

        private void remove_btn_Click(object sender, EventArgs e)
        {
            //RemoveForm rf = new RemoveForm();
            //this.Hide();
            //rf.Show();
           // panel_rm.Enabled = true;
           /* for (int i = 0; i < 4; i++)
            {
                if (items[i].ItemId == textBox1.Text)
                {
                    if (items[i].quantity == 0)
                    {
                        items[i].ItemId = "";
                        items[i].ItemName = "";
                        items[i].price = 0;
                    }
                    else
                    {
                        int q = items[i].quantity;
                        items[i].quantity--;
                        items[i].price = (items[i].price / q) * items[i].quantity;
                    }
                    MessageBox.Show("Items Quantity Has been decreased .");
                }
            }
            refresh();*/
        }

        private void proceed_btn_Click(object sender, EventArgs e)
        {

            if (int.Parse(totalPrice.Text) != 0)
            {
                pf.Show();
                button_order.Enabled = true;
            }
            else 
            {
                label14.Visible = true;
            }
        }

        private void CartForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label14.Visible = false;
            //this.Hide
            sp.Show();
            
            items=sp.getArray();
            
            
        }
        private void refresh()
        {
            counter = sp.getCounter();

            if (counter == 1)
            {
                Item1_id.Text = items[0].ItemId;

                textBox_name1.Text = items[0].ItemName;
                numericUpDown1.Value = items[0].quantity;
               


                Item1_price.Text = items[0].price.ToString();
                string total = items[0].price.ToString();
                totalPrice.Text = total;


            }
            else if (counter == 2)
            {

                Item1_id.Text = items[0].ItemId;
                Item2_id.Text = items[1].ItemId;

                textBox_name1.Text = items[0].ItemName;
                textBox_name2.Text = items[1].ItemName;

                numericUpDown1.Value = items[0].quantity;
                numericUpDown2.Value = items[1].quantity;
              



                Item1_price.Text = items[0].price.ToString();
                Item2_price.Text = items[1].price.ToString();

                string total = (items[0].price + items[1].price).ToString();
                totalPrice.Text = total;

            }
            else if (counter == 3)
            {


                Item1_id.Text = items[0].ItemId;
                Item2_id.Text = items[1].ItemId;
                Item3_id.Text = items[2].ItemId;

                textBox_name1.Text = items[0].ItemName;
                textBox_name2.Text = items[1].ItemName;
                textBox_name3.Text = items[2].ItemName;

                numericUpDown1.Value = items[0].quantity;
                numericUpDown2.Value = items[1].quantity;
                numericUpDown3.Value = items[2].quantity;



                Item1_price.Text = items[0].price.ToString();
                Item2_price.Text = items[1].price.ToString();
                Item3_price.Text = items[2].price.ToString();
                string total = (items[0].price + items[1].price + items[2].price).ToString();
                totalPrice.Text = total;
            }
            else if (counter == 4)
            {
                Item1_id.Text = items[0].ItemId;
                Item2_id.Text = items[1].ItemId;
                Item3_id.Text = items[2].ItemId;
                Item4_id.Text = items[3].ItemId;

                textBox_name1.Text = items[0].ItemName;
                textBox_name2.Text = items[1].ItemName;
                textBox_name3.Text = items[2].ItemName;
                textBox_name4.Text = items[3].ItemName;

                numericUpDown1.Value = items[0].quantity;
                numericUpDown2.Value = items[1].quantity;
                numericUpDown3.Value = items[2].quantity;
                numericUpDown4.Value = items[3].quantity;


                Item1_price.Text = items[0].price.ToString();
                Item2_price.Text = items[1].price.ToString();
                Item3_price.Text = items[2].price.ToString();
                Item4_price.Text = items[3].price.ToString();
                string total = (items[0].price + items[1].price + items[2].price + items[3].price).ToString();
                totalPrice.Text = total;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          //  remove_btn.Enabled = true;

            refresh();
            item1_lab.Enabled = true;
            item2_lab.Enabled = true;
            item3_lab.Enabled = true;
            item4_lab.Enabled = true;
            proceed_btn.Visible = true;
            proceed_btn.Enabled = true;
            

        }

        private void button_order_Click(object sender, EventArgs e)
        {
            send();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Client cl = new Client();
            this.Hide();
            cl.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Client cl = new Client();
            this.Hide();
            cl.Show();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            int x = int.Parse(Item1_price.Text);
            /*for (int i = 0; i < counter-1; i++) 
            {
                items[i] = items[i + 1];
            }
            counter--;*/
            item1_lab.Enabled = false;
            Item1_id.Text = "";
            textBox_name1.Text = "";
            numericUpDown1.Value = 0;
            Item1_price.Text = "00";
            totalPrice.Text = (int.Parse(totalPrice.Text) - x).ToString();
            items[0].ItemId = "00";
            items[0].ItemName = "00";
            items[0].quantity = 00;
            items[0].price = 00;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {/*
            int u1 =items[0].price/items[0].quantity;
            numericUpDown1.Value += 1;
            
            
            */
        }

        private void button5_Click(object sender, EventArgs e)
        {
           // int u1, u2, u3, u4;
            if (counter == 4)
            {
                if (numericUpDown1.Value != 0)
                {
                    int price1 = Int32.Parse(Item1_price.Text);
                    int u1 = price1 / items[0].quantity;
                    
                    Item1_price.Text = (numericUpDown1.Value * u1).ToString();
                    items[0].quantity = Convert.ToInt32(numericUpDown1.Value);
                    //refresh();
                }
                if (numericUpDown2.Value != 0)
                {
                    int price2 = Int32.Parse(Item2_price.Text);
                    int u2 = price2 / items[1].quantity;
                    Item2_price.Text = (numericUpDown2.Value * u2).ToString();
                    items[1].quantity = Convert.ToInt32(numericUpDown2.Value);
                }

                if (numericUpDown3.Value != 0)
                {
                    int price3 = Int32.Parse(Item3_price.Text);
                    int u3 = price3 / items[2].quantity;
                    Item3_price.Text = (numericUpDown3.Value * u3).ToString();
                    items[2].quantity = Convert.ToInt32(numericUpDown3.Value);
                }

                if (numericUpDown4.Value != 0)
                {
                    int price4 = Int32.Parse(Item4_price.Text);
                    int u4 = price4 / items[3].quantity;
                    Item4_price.Text = (numericUpDown3.Value * u4).ToString();
                    items[3].quantity = Convert.ToInt32(numericUpDown4.Value);
                }
                totalPrice.Text = (int.Parse(Item1_price.Text) + int.Parse(Item2_price.Text) + int.Parse(Item3_price.Text) + int.Parse(Item4_price.Text)).ToString();
            }
            else if (counter == 3)
            {
                if (numericUpDown1.Value != 0)
                {
                    int price1 = Int32.Parse(Item1_price.Text);
                    int u1 = price1 / items[0].quantity;
                    Item1_price.Text = (numericUpDown1.Value * u1).ToString();
                    items[0].quantity = Convert.ToInt32(numericUpDown1.Value);
                    //refresh();
                }
                if (numericUpDown2.Value != 0)
                {
                    int price2 = Int32.Parse(Item2_price.Text);
                    int u2 = price2 / items[1].quantity;
                    
                    Item2_price.Text = (numericUpDown2.Value * u2).ToString();
                    items[1].quantity = Convert.ToInt32(numericUpDown2.Value);
                }
                if (numericUpDown3.Value != 0)
                {
                    int price3 = Int32.Parse(Item3_price.Text);
                    int u3 = price3 / items[2].quantity;
                   
                    Item3_price.Text = (numericUpDown3.Value * u3).ToString();
                    items[2].quantity = Convert.ToInt32(numericUpDown3.Value);
                }
                

                totalPrice.Text = (int.Parse(Item1_price.Text) + int.Parse(Item2_price.Text) + int.Parse(Item3_price.Text)).ToString();
            }
            else if (counter == 2) 
            {
                if (numericUpDown1.Value != 0)
                {
                    int price1 = Int32.Parse(Item1_price.Text);
                    int u1 = price1 / items[0].quantity;
                    
                    Item1_price.Text = (numericUpDown1.Value * u1).ToString();
                    items[0].quantity = Convert.ToInt32(numericUpDown1.Value);
                    //refresh();
                }
                if (numericUpDown2.Value != 0)
                {
                    int price2 = Int32.Parse(Item2_price.Text);
                    int u2 = price2 / items[1].quantity;
                    
                    Item2_price.Text = (numericUpDown2.Value * u2).ToString();
                    items[1].quantity = Convert.ToInt32(numericUpDown2.Value);
                }
                totalPrice.Text = (int.Parse(Item1_price.Text) + int.Parse(Item2_price.Text)).ToString();
            }
            else if (counter == 1) 
            {
                if (numericUpDown1.Value != 0)
                {
                    int price1 = Int32.Parse(Item1_price.Text);
                    int u1 = price1 / items[0].quantity;
                    Item1_price.Text = (numericUpDown1.Value * u1).ToString();
                    items[0].quantity = Convert.ToInt32(numericUpDown1.Value);
                    totalPrice.Text = (int.Parse(Item1_price.Text)).ToString();
                }
            }
        }

        private void item2_lab_Click(object sender, EventArgs e)
        {
            int x = int.Parse(Item2_price.Text);
            
            item2_lab.Enabled = false;
            Item2_id.Text = "";
            textBox_name2.Text = "";
            numericUpDown2.Value = 0;
            Item2_price.Text = "00";
            totalPrice.Text = (int.Parse(totalPrice.Text) - x).ToString();
            items[1].ItemId = "00";
            items[1].ItemName = "00";
            items[1].quantity = 00;
            items[1].price = 00;
        }

        private void item3_lab_Click(object sender, EventArgs e)
        {
            int x = int.Parse(Item3_price.Text);
            
            item3_lab.Enabled = false;
            Item3_id.Text = "";
            textBox_name3.Text = "";
            numericUpDown3.Value = 0;
            Item3_price.Text = "00";
            totalPrice.Text = (int.Parse(totalPrice.Text) - x).ToString();
            items[2].ItemId = "00";
            items[2].ItemName = "00";
            items[2].quantity = 00;
            items[2].price = 00;
        }

        private void item4_lab_Click(object sender, EventArgs e)
        {
            int x = int.Parse(Item4_price.Text);
            
            item4_lab.Enabled = false;
            Item4_id.Text = "";
            textBox_name4.Text = "";
            numericUpDown4.Value = 0;
            Item4_price.Text = "00";
            totalPrice.Text = (int.Parse(totalPrice.Text) - x).ToString();
            items[3].ItemId = "00";
            items[3].ItemName = "00";
            items[3].quantity = 00;
            items[3].price = 00;
        }
    }
}
