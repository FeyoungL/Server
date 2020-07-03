using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Sever
{
    public partial class MainForm : Form
    {
        Thread serverThread;
        //readonly string IPAdddr = "127.0.0.1";
        readonly int IPPort = 6060;
        readonly StringBuilder Content;

        Socket serverSocket;
        Socket connectSocket;
        List<Thread> recvThreads = new List<Thread>();

        Dictionary<string, Socket> clientItems = new Dictionary<string, Socket>();

        public MainForm()
        {
            InitializeComponent();

            Content = new StringBuilder();

        }

        private void appendContent(byte[] buffer, int len)
        {
            if(buffer == null || len == 0)
            {
                return;
            }

            //Content.AppendLine(Encoding.UTF8.GetString(buffer));
            Rtb_Msg.AppendText(Encoding.UTF8.GetString(buffer));
        }

        private void appendContent(string msg)
        {
            //Content.AppendLine(msg);
            //UpdateRtb();
            Rtb_Msg.AppendText(msg + "\n");
        }

        private void UpdateRtb()
        {
            Rtb_Msg.Text = Content.ToString();
        }

        private string GetLocalIP()
        {
            IPAddress[] addressList = Dns.GetHostAddresses(Dns.GetHostName());
            return addressList[1].ToString();
        }

        private void ServerHandler()
        {
            try
            {
                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(GetLocalIP()), IPPort);

                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(iep);

                serverSocket.Listen(10);

                //Console.WriteLine(GetLocalIP());
                Console.WriteLine("Server: " + serverSocket.LocalEndPoint.ToString());
                //appendContent("等待连接中...");
                Console.WriteLine("等待连接中...");

            }
            catch (Exception)
            {
                Console.WriteLine("ServerHandler()");
            }
        }

        private void Listening()
        {
            try
            { 
                while(true)
                {

                    connectSocket = serverSocket.Accept();

                    clientItems.Add((connectSocket.RemoteEndPoint as IPEndPoint).ToString(), connectSocket);

                    Console.WriteLine((connectSocket.RemoteEndPoint as IPEndPoint).ToString());

                    Invoke(new AddItemsDelegate(AddItems), new object[] { (connectSocket.RemoteEndPoint as IPEndPoint).ToString() });

                    AddItems((connectSocket.RemoteEndPoint as IPEndPoint).ToString());

                    recvThreads.Add(new Thread(new ParameterizedThreadStart(ReceiveForm))
                    {
                        IsBackground = true,
                    });

                    recvThreads.Last().Start(connectSocket);
                }
                

            }
            catch (Exception)
            {
                Console.WriteLine("ServerHandler()");
            }
        }


        private void ReceiveForm(object clientSocket)
        {
            byte[] buffer = new byte[2048];
            int len;
            try
            {
                while (true)
                {
                    len = ((Socket)clientSocket).Receive(buffer);
                    Console.WriteLine("信息: " + Encoding.UTF8.GetString(buffer, 0, len));
                    //appendContent(buffer, len);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ReceiveForm()");
            }
        }

        private delegate void AddItemsDelegate(string addr);

        private void AddItems(string addr)
        {
            Cb_ClientAddr.Items.Add(addr);

            if (Cb_ClientAddr.Items.Count == 1)
            {
                Cb_ClientAddr.SelectedIndex = 0;
            }
        }

        private void Rtb_Msg_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                
                byte[] data = Encoding.Default.GetBytes(Rtb_Msg.Text);
                clientItems[Cb_ClientAddr.Text.ToString()].Send(data, data.Length, SocketFlags.None);
            }
        }

        private void Form_Disposed(object sender, EventArgs e)
        {
            if(serverSocket != null && serverSocket.Connected == true)
            {
                serverSocket.Disconnect(true);
                serverSocket.Dispose();
            }
        }


        private void Btn_Create_Click(object sender, EventArgs e)
        {
            Content.Clear();

            ServerHandler();

            serverThread = new Thread(Listening)
            {
                IsBackground = true
            };

            serverThread.Start();

        }

        

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            foreach (Thread item in recvThreads)
            {
                item.Abort();
            }

            if(serverThread != null)
            {
                serverThread.Abort();
            }
        }
    }
}
