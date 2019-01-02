using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

using System.Data.SqlClient;

namespace Online_Shop_Project
{
    class MainServer
    {
        private static string conString = "Data Source=DESKTOP-ARCJRDG\\SUPTO_DB;Initial Catalog=projectDB;Integrated Security=True";

        private static string ip = "127.0.0.1";
        private static byte[] _buffer = new byte[1024];
        private static List<Socket> _clientSockets = new List<Socket>();
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
            SetupServer();
            Console.Read();
        }
        private static void SetupServer()
        {
            Console.WriteLine("Setting up server....");
            _serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ip), 8080));
            _serverSocket.Listen(1); //Backlog
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private static void AcceptCallback(IAsyncResult AR)
        {
            Console.WriteLine("Client Connected....");
            Socket socket = _serverSocket.EndAccept(AR);
            _clientSockets.Add(socket);
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(RecieveCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private static void RecieveCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int recieved = socket.EndReceive(AR);
            byte[] dataBuf = new byte[recieved];
            Array.Copy(_buffer, dataBuf, recieved);

            string text = Encoding.ASCII.GetString(dataBuf);
            Console.WriteLine("Text received: " + text);

            string response = string.Empty;
            string[] cmdArray = text.Split(';');
            string cmd = cmdArray[0];
            Console.WriteLine(cmd);

            if (cmd == "login")
            {
                
                string userName = cmdArray[1];
                string password = cmdArray[2];
                Console.WriteLine(userName);
                Console.WriteLine(password);
                response= LogIn(userName,password);                
            }
            else if (cmd == "signup")
            {
                string userName = cmdArray[1];
                string fullName = cmdArray[2];
                string password = cmdArray[3];
                string email = cmdArray[4];
                response = SignUP(userName,fullName,password,email);
            }
            else if(cmd == "order")
            {
                string[] item1 = cmdArray[1].Split('&');
                string item1ID = item1[0];
                string item1Quantity = item1[1];
                
                string[] item2 = cmdArray[2].Split('&');
                string item2ID = item2[0];
                string item2Quantity = item2[1];
               
                string[] item3 = cmdArray[3].Split('&');
                string item3ID = item3[0];
                string item3Quantity = item3[1];
                
                string[] item4 = cmdArray[4].Split('&');
                string item4ID = item4[0];
                string item4Quantity = item4[1];
                
                string phone = cmdArray[5];
                string billAdd = cmdArray[6];
                string tId = cmdArray[7];
                string counter = cmdArray[8];
                string totalPrice = cmdArray[9];
                string query="";
                string query2 = "";

                DateTime date = new DateTime();
                date = DateTime.Now;
                Console.WriteLine("current date: "+ date);

                if (counter.Equals("4"))
                {
                    query = "insert into showOrder_admin (phoneNo,totalPrice,orderTime,status) values ('" + phone + "','" + totalPrice + "','" +date.ToString("MM-dd-yyyy") + "','PENDING')";
                    query2 = "insert into orderItem (item1,quantity1,item2,quantity2,item3,quantity3,item4,quantity4,address,tranId) values ('" + item1ID + "','" + item1Quantity + "','" + item2ID + "','" + item2Quantity + "','" + item3ID + "','" + item3Quantity + "','" + item4ID + "','" + item4Quantity + "','" + billAdd + "','" +tId +"')";
                }
                else if (counter.Equals("3"))
                {
                    query = "insert into showOrder_admin (phoneNo,totalPrice,orderTime,status) values ('" + phone + "','" + totalPrice + "','" + date.ToString("MM-dd-yyyy") + "','PENDING')";
                    query2 = "insert into orderItem (item1,quantity1,item2,quantity2,item3,quantity3,address,tranId) values ('" + item1ID + "','" + item1Quantity + "','" + item2ID + "','" + item2Quantity + "','" + item3ID + "','" + item3Quantity + "','" + billAdd + "','" + tId + "')";
                }
                else if (counter.Equals("2"))
                {

                    query = "insert into showOrder_admin (phoneNo,totalPrice,orderTime,status) values ('" + phone + "','" + totalPrice + "','" + date.ToString("MM-dd-yyyy") + "','PENDING')";
                    query2 = "insert into orderItem (item1,quantity1,item2,quantity2,address,tranId) values ('" + item1ID + "','" + item1Quantity + "','" + item2ID + "','" + item2Quantity + "','" + billAdd + "','" + tId + "')";
                }
                else if (counter.Equals("1"))
                {
                    query = "insert into showOrder_admin (phoneNo,totalPrice,orderTime,status) values ('" + phone + "','" + totalPrice + "','" + date.ToString("MM-dd-yyyy") + "','PENDING')";
                    query2 = "insert into orderItem (item1,quantity1,address,tranId) values ('" + item1ID + "','" + item1Quantity + "','"  + billAdd + "','" + tId + "')";
                }
                
                SqlConnection conn1=new SqlConnection(conString);
                conn1.Open();
                SqlCommand sq = new SqlCommand(query,conn1);
                SqlCommand sq1 = new SqlCommand(query2, conn1);
                sq.ExecuteNonQuery();
                sq1.ExecuteNonQuery();
            }
            else
            {
                Console.WriteLine("Error occured RESTART SERVER");
            }

            Console.WriteLine(response);
            byte[] data = Encoding.ASCII.GetBytes(response);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(RecieveCallback), socket);
            
        }

        private static string SignUP(string userName, string fullName, string password, string email)
        {
            try
            {
                SqlConnection conn = new SqlConnection(conString); //connection to database
                string query = "insert into admin_login_info(UserName,Password,FullName,Email) values('"+userName+"','"+password +"','"+fullName+"','"+email+"')";
                SqlCommand com = new SqlCommand(query, conn);
                conn.Open();
                
                SqlDataReader Dr = com.ExecuteReader();
                return "signup";
            }
            catch(SqlException se)
            {
                Console.WriteLine("Exeption: "+se);
            }
            return null;
        }

        private static void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }
       

        private static string LogIn(string userName, string passward)
        {
            string user = userName;
            string pass = passward;
            try
            {
                SqlConnection conn = new SqlConnection(conString); //connection to database

                string query = "select * from admin_login_info where UserName=@user and Password=@pw";
                SqlCommand com = new SqlCommand(query, conn);
                conn.Open();
                com.Parameters.AddWithValue("@user", userName);
                com.Parameters.AddWithValue("@pw", passward);
                SqlDataReader Dr = com.ExecuteReader();

                if (Dr.HasRows == true)
                {
                    return "login";
                }
                else
                {
                    return "failed";
                }
                
            }
            catch (SqlException sq)
            { 
                Console.WriteLine(sq);
                return null;
            }

        }
    }
}
