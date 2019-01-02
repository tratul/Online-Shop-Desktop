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
using System.IO;

namespace WindowsFormsApplication3
{
    public partial class SignUp_Form : Form
    {
        const int PORT_NO = 8080;
        const string SERVER_IP = "127.0.0.1";
        private static Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public SignUp_Form()
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

        private void button_signUp_Click(object sender, EventArgs e)
        {
            string userName = textBox_userName.Text;
            string fullName = textBox_fullName.Text;
            string pass = textBox_pass.Text;
            string conPass = textBox_confirmPass.Text;
            string email = textBox_email.Text;

            string textToSend = "signup;" + userName + ";" + fullName + ";" + pass + ";" + email;
            if (textBox_userName.Text != "" && textBox_pass.Text != "" && textBox_confirmPass.Text != "" && textBox_email.Text != "" && textBox_fullName.Text != "")
            {
                if (textBox_email.Text.Contains("@") && textBox_email.Text.Contains(".com"))
                {
                    if (pass.Equals(conPass))
                    {
                        byte[] buffer = Encoding.ASCII.GetBytes(textToSend);
                        client.Send(buffer);

                        byte[] receivedBuf = new byte[1024];
                        int rec = client.Receive(receivedBuf);
                        byte[] data = new byte[rec];
                        Array.Copy(receivedBuf, data, rec);

                        string receivedMsg = Encoding.ASCII.GetString(data);

                        if (receivedMsg.Equals("signup"))
                        {
                            MessageBox.Show("THANK YOU FOR CHOOSING OUR APP");
                        }
                        else
                            MessageBox.Show("Something went wrong :( ");
                    }
                    else
                    {
                        MessageBox.Show("Password Doesn't Match");
                    }
                }
                else
                {
                    MessageBox.Show("Enter Valid Email!!!");
                }
            }
            else
            {
                label7.Visible = true;
            }
        }

        private void LoginSU_click(object sender, EventArgs e)
        {
            Client cl = new Client();
            this.Hide();
            
            cl.Show();

        }

        private void textBox_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Client cn = new Client();
            this.Hide();
            cn.Show();
        }
    }
}
