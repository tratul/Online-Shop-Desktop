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
    public partial class Client : Form
    {
        const int PORT_NO = 8080;
        const string SERVER_IP = "127.0.0.1";
        private static Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        //TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
        
        public Client()
        {
            InitializeComponent();
            if (!client.Connected)
            {
                client.Connect(IPAddress.Parse(SERVER_IP), PORT_NO);
            }
            else 
            {
                Console.WriteLine("");
            }
                
            
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void send_Click(object sender, EventArgs e)
        {
            if (textBox_send.Text != null && passField.Text != null)
            {
                string userName = textBox_send.Text;
                string pass = passField.Text;//unfinished
                string textToSend = "login;" + userName + ";" + pass;

                byte[] buffer = Encoding.ASCII.GetBytes(textToSend);
                client.Send(buffer);

                byte[] receivedBuf = new byte[1024];
                int rec = client.Receive(receivedBuf);
                byte[] data = new byte[rec];
                Array.Copy(receivedBuf, data, rec);

                string receivedMsg = Encoding.ASCII.GetString(data);

                if (receivedMsg.Equals("login"))
                {
                    //MessageBox.Show("LOGGED IN");
                    CartForm cf = new CartForm();
                    this.Hide();
                    cf.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect User Name or Password");
                }
            }
            else
            {
                MessageBox.Show("Insert Username and Password");
            }
        }

        private void button_signUp_Click(object sender, EventArgs e)
        {
            
            SignUp_Form sf = new SignUp_Form();
            this.Hide();
            sf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
