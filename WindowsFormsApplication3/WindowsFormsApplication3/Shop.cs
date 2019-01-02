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
    public partial class Shop : Form
    {
        
        int m1=0,m2=0,m3=0,m4=0,m5=0,m6=0,m7=0,m8=0,m9=0;
        public int counter=0;
        int a1=0, a2=0, a3=0, a4=0, a5=0, a6=0, a7=0, a8=0, a9=0, w1=0, w2=0, w3=0, w4=0, w5=0, w6=0, w7=0, w8=0, w9=0;
        public  Item[] items = new Item[4];
        public static Item it = new Item();
        
        Item  i = new Item();
        
        public Shop()
        {

            InitializeComponent();
            panel_women.Visible = false;
            
            panel_men.Visible = true;
            


            it.ItemId = "0";
            it.ItemName= "";
            it.quantity = 0;
            it.price = 0;
            items[0] = new Item();
            items[1] = new Item();
            items[2] = new Item();
            items[3] = new Item();
            

        }

        public Item[] getArray()
        {
         return (items);
        }
        public int getCounter()
        {
            return (counter);
        }

        private void cart_button_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            
        }

        private void Button_Click(object sender, EventArgs e)
        {

        }

        private void Shop_Load(object sender, EventArgs e)
        {   
            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void men_next(object sender, EventArgs e)
        {
            panel_women.Visible = true;
            
            panel_men.Visible = false;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            panel_women.Visible = false;
            
            panel_men.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel_women.Visible = false;
            
            panel_men.Visible = false;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            panel_women.Visible = true;
            
            panel_men.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel_women.Visible = true;
           
            panel_men.Visible = false;
        }
        public void fillAt0(string ii,string iname , int qu , int price)
        {
            if (counter == 0)
            {
                items[0].ItemId = ii;
                items[0].ItemName = iname;
                items[0].quantity = qu;
                items[0].price = price * i.quantity;
               
                counter++;
               

                items[1].ItemId = ii;
                items[2].ItemId = ii;
                items[3].ItemId = ii;
                textBox_qnt.Text = qu.ToString();
            }
            
        }
        public void fillArray(string ii, string iname, int qu, int price)
        {
            int flag = 0;
           
            for (int i = 0; i < 4; i++)
            {
                

                if (items[i].ItemId.Equals(ii))
                {

                    items[i].quantity = qu;
                    items[i].price = price * items[i].quantity;

                    flag = 1;
                    textBox_qnt.Text = qu.ToString();
                    break;
                }
                
            }

            
            if (flag == 0)
            {
                if (counter < 4 && counter > 0)
                {


                    items[counter].ItemId = ii;
                    items[counter].ItemName = iname;
                    items[counter].quantity = qu;
                    items[counter].price = price;
                    counter++;
                    textBox_qnt.Text = qu.ToString();


                }
                else
                {
                    MessageBox.Show("NOT MORE THEN 4 Items");
                    textBox_qnt.Text = "0";
                }
                
               

            }
        }

        private void deleteItem(string ii)
        {
            int p = 11;
            for (int i = 0; i < 4; i++)
            {
                if(items[i].ItemId.Equals(ii))
                {
                   p = i;
                }
            }

            for (int j = p; p < counter - 1; j++)
            {
                items[j] = items[j + 1];
            }
        }



        private void men1Btn_Click(object sender, EventArgs e)
        {
            
                m1 += 1;
                string item1Id = "11";
                string itemName = "moneyBag";
                int price = 150;
                pictureBox10.Visible = true;
                //MessageBox.Show("button 1 click");
                if (counter == 0)
                {
                    fillAt0(item1Id, itemName, m1, price);
                    //MessageBox.Show("button 1 click for 0");
                }
                else if (counter > 0 && counter < 5)
                {
                    fillArray(item1Id, itemName, m1, price);

                }
                else
                {
                    MessageBox.Show("More then 4 items");
                    m1 = 0;
                }
            
        }
        private void men2Btn_Click(object sender, EventArgs e)
        {
            
                m2 += 1;
                string item2Id = "12";
                string itemName = "T-shirts";
                int price = 200;
                pictureBox11.Visible = true;

                //MessageBox.Show("button 2 click");
                if (counter == 0)
                {
                    fillAt0(item2Id, itemName, m1, price);
                }
                else if (counter > 0 && counter < 5)
                {
                    fillArray(item2Id, itemName, m2, price);
                }
                else
                {
                    MessageBox.Show("More then 4 items");
                }
            
        }

        private void men3Btn_Click(object sender, EventArgs e)
        {
            
                m3 += 1;
                string item3Id = "13";
                string itemName = "Jeans";
                int price = 1300;
                pictureBox12.Visible = true;
                //MessageBox.Show("button 3 click");
                if (counter == 0)
                {
                    fillAt0(item3Id, itemName, m3, price);
                }
                else if (counter > 0 && counter < 5)
                {
                    fillArray(item3Id, itemName, m3, price);
                }
                else
                {
                    MessageBox.Show("More then 4 items");
                }
            
            

        }

        private void men4Btn_Click(object sender, EventArgs e)
        {
            
			pictureBox13.Visible = true;
            m4 += 1;
            string itemId = "14";
            string itemName = "Belt";
            int price = 250;

            if (counter == 0)
            {
                fillAt0(itemId, itemName, m4, price);
                //MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, m4, price);
                //MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }
            

        }

        private void men5Btn_Click(object sender, EventArgs e)
        {
            
			pictureBox14.Visible = true;
            m5 += 1;
            string itemId = "15";
            string itemName = "Pant";
            int price = 700;
            fillArray(itemId, itemName, m5, price);
            if (counter == 0)
            {
                fillAt0(itemId, itemName, m5, price);
               // MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, m5, price);
               // MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }
            
        }

        private void men6Btn_Click(object sender, EventArgs e)
        {
           
			pictureBox15.Visible = true;
            m6 += 1;
            string itemId = "16";
            string itemName = "shirt";
            int price = 550;
            fillArray(itemId, itemName, m6, price);
            if (counter == 0)
            {
                fillAt0(itemId, itemName, m6, price);
                //MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, m6, price);
                //MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }

        }

        private void men7Btn_Click(object sender, EventArgs e)
        {
            
			pictureBox16.Visible = true;
            m7 += 1;
            string itemId = "17";
            string itemName = "sunglass";
            int price = 250;
            
            if (counter == 0)
            {
                fillAt0(itemId, itemName, m7, price);
                //MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, m7, price);
                //MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }

        }

        private void men8Btn_Click(object sender, EventArgs e)
        {
           
                pictureBox17.Visible = true;
            m8 += 1;
            string itemId = "18";
            string itemName = "Bag";
            int price = 2400;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, m8, price);
                //MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, m8, price);
                //MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }
            
        }

        private void men9Btn_Click(object sender, EventArgs e)
        {
          
			pictureBox18.Visible = true;
            m9 += 1;
            string itemId = "19";
            string itemName = "clothings";
            int price = 800;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, m9, price);
                //MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, m9, price);
                //MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }

           
        }

        private void A1btn_Click(object sender, EventArgs e)
        {
            a1 += 1;
            string itemId = "21";
            string itemName = "leather moneybag";
            int price = 550;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, a1, price);
                //MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, a1, price);
               // MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }
        }

        private void A2btn_Click(object sender, EventArgs e)
        {
            a2 += 1;
            string itemId = "22";
            string itemName = "leather bag";
            int price = 3000;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, a2, price);
               // MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, a2, price);
                //MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }
        }

        private void A3btn_Click(object sender, EventArgs e)
        {
            a3 += 1;
            string itemId = "23";
            string itemName = "wallet";
            int price = 500;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, a3, price);
                //MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, a3, price);
                //MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }
        }

        private void A4btn_Click(object sender, EventArgs e)
        {
            a4 += 1;
            string itemId = "24";
            string itemName = "leather belt";
            int price = 400;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, a4, price);
                //MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, a4, price);
                //MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }
        }

        private void A5btn_Click(object sender, EventArgs e)
        {
            a5 += 1;
            string itemId = "25";
            string itemName = "breslette";
            int price = 1500;
            fillArray(itemId, itemName, a5, price);
            if (counter == 0)
            {
                fillAt0(itemId, itemName, a5, price);
               // MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, a5, price);
                //MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }
        }

        private void A6btn_Click(object sender, EventArgs e)
        {
            a6 += 1;
            string itemId = "26";
            string itemName = "Necklace";
            int price =2550;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, a6, price);
                //MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, a6, price);
               // MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }
        }

        private void A7btn_Click(object sender, EventArgs e)
        {
            a7 += 1;
            string itemId = "27";
            string itemName = "Hair Band";
            int price = 250;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, a7, price);
               // MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, a7, price);
                //MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }
        }

        private void A8btn_Click(object sender, EventArgs e)
        {
            a8 += 1;
            string itemId = "28";
            string itemName = "varity bag";
            int price = 3500;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, a8, price);
               // MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, a8, price);
              //  MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }
        }

        private void A9btn_Click(object sender, EventArgs e)
        {
            a9+= 1;
            string itemId = "29";
            string itemName = "ear ring";
            int price = 5500;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, a9, price);
               // MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, a9, price);
               // MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }
        }

        private void W1btn_Click(object sender, EventArgs e)
        {
            
            
            w1 += 1;
            string itemId = "31";
            string itemName = "ladys bag";
            int price = 1500;
           //labelW1.Visible = true;
           pictureBox1.Visible = true;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, w1, price);
               // MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, w1, price);
              //  MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }
            
            
        }

        private void W2btn_Click(object sender, EventArgs e)
        {
           
                pictureBox2.Visible = true;
            w2 += 1;
            string itemId = "32";
            string itemName = "black dress";
            int price = 2500;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, w2, price);
               // MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, w2, price);
              //  MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }

        }

        private void W3btn_Click(object sender, EventArgs e)
        {
         	pictureBox3.Visible = true;
            w3 += 1;
            string itemId = "33";
            string itemName = "three Piece";
            int price = 2800;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, w3, price);
               // MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, w3, price);
               // MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }

            
        }

        private void W4btn_Click(object sender, EventArgs e)
        {
            
                pictureBox4.Visible = true;
            w4 += 1;
            string itemId = "34";
            string itemName = "anarkoli";
            int price = 3500;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, w4, price);
              //  MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, w4, price);
               // MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }
            
        }

        private void W5btn_Click(object sender, EventArgs e)
        {
            
			pictureBox5.Visible = true;
            w5 += 1;
            string itemId = "35";
            string itemName = "lehenga";
            int price = 10000;
            fillArray(itemId, itemName, w5, price);
            if (counter == 0)
            {
                fillAt0(itemId, itemName, w5, price);
                //MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, w5, price);
               // MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }

        }

        private void W6btn_Click(object sender, EventArgs e)
        {
            
                pictureBox6.Visible = true;
            w6 += 1;
            string itemId = "36";
            string itemName = "saree(blue)";
            int price = 8800;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, w6, price);
              //  MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, w6, price);
              //  MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }
            
        }

        private void W7btn_Click(object sender, EventArgs e)
        {
            
			pictureBox7.Visible = true;
            w7 += 1;
            string itemId = "37";
            string itemName = "Jamdani";
            int price = 12000;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, w7, price);
              //  MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, w7, price);
               // MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }

        }

        private void W8btn_Click(object sender, EventArgs e)
        {
            
                pictureBox8.Visible = true;
            w8 += 1;
            string itemId = "38";
            string itemName = "butique";
            int price =2500;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, w8, price);
               // MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, w8, price);
               // MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }
           
        }

        private void W9btn_Click(object sender, EventArgs e)
        {
            
			pictureBox9.Visible = true;
            w9 += 1;
            string itemId = "39";
            string itemName = "three Piece(green)";
            int price = 3000;
            if (counter == 0)
            {
                fillAt0(itemId, itemName, w9, price);
               // MessageBox.Show("button 1 click for 0");
            }
            else if (counter > 0 && counter < 5)
            {
                fillArray(itemId, itemName, w9, price);
              //  MessageBox.Show("button 1 click");
            }
            else
            {
                MessageBox.Show("More then 4 items");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //pictureBox1.Visible = false;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            panel_women.Visible = false;
           
            panel_men.Visible = false;
        }

        private void panel_acs_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

