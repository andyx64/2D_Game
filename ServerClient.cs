using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace _2dGame
{
    class ServerClient : INotifyPropertyChanged
    {
        


        Socket socket;
        EndPoint epLocal, epRemote;
        byte[] buffer;

        string localIP;
        string localPORT;

        string remoteIP;
        string remotePORT;

        string receivedMessage;

        public event PropertyChangedEventHandler PropertyChanged;

        public ServerClient( string _localIP,string _localPORT, string _remoteIP, string _remotePORT)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            LocalIP = _localIP;
            LocalPORT = _localPORT;
            RemoteIP = _remoteIP;
            RemotePORT = _remotePORT;
            this.Connect();
        }

        public string LocalIP
        {
            get { return localIP; }
            set { localIP = value; }
        }
        public string LocalPORT
        {
            get { return localPORT; }
            set { localPORT = value; }
        }
        public string RemoteIP
        {
            get { return remoteIP; }
            set { remoteIP = value; }
        }
        public string RemotePORT
        {
            get { return remotePORT; }
            set { remotePORT = value; }
        }
        public string ReceivedMessage
        {
            get { return receivedMessage; }
            set { receivedMessage = value; NotifyPropertyChanged(); }
        }
 




        public static string GetLocalIp()
        {
            IPHostEntry host;
            host =  Dns.GetHostEntry(Dns.GetHostName());
            foreach(IPAddress ip in host.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }
        public void Connect()
        {

                epLocal = new IPEndPoint(IPAddress.Parse(localIP), Convert.ToInt32(localPORT));
                socket.Bind(epLocal);

                epRemote = new IPEndPoint(IPAddress.Parse(remoteIP), Convert.ToInt32(remotePORT));
                socket.Connect(epRemote);

                buffer = new byte[1500];
                socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
        }

        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                byte[] receivedData = new byte[1500];
                receivedData = (byte[])aResult.AsyncState;

                ASCIIEncoding aEncoding = new ASCIIEncoding();
                ReceivedMessage = aEncoding.GetString(receivedData);
                //eingehendes Signal 
                


                buffer = new byte[1500];
                socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Server error:" + ex);
            }

        }
        public void Send(string data)
        {
            ASCIIEncoding aEncoding = new ASCIIEncoding();
            byte[] sendingMessage = new byte[1500];
            sendingMessage = aEncoding.GetBytes(data);
            socket.Send(sendingMessage);
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public double GetReceivedMessage()
        {
            double tmp;
            if(ReceivedMessage != "0")
            {
                if(double.TryParse(ReceivedMessage,out tmp))
                {
                    return tmp;
                }
                else
                {
                    return 0;
                }                  
            }
            else
            {
                return 0;
            }
        }

        public static string MakeDataPackage(PlayerObject playerObject)
        {
            string package = Convert.ToString(playerObject.X) + "/" + Convert.ToString(playerObject.Y) + "/" +Convert.ToString(playerObject.GetLeft) + "/" + Convert.ToString(playerObject.GetTop);

            return package;
        } 

        public static void RemakeDataPackage(string datapackage, PlayerObject playerobj)
        {
            if(datapackage != null)
            {
               
                String[] substrings = datapackage.Split('/');

                if (substrings.Length == 4)
                {
                    double.TryParse(substrings[0], out double tmp0);
                    double.TryParse(substrings[1], out double tmp1);
                    double.TryParse(substrings[2], out double tmp2);
                    double.TryParse(substrings[3], out double tmp3);

                    playerobj.X = tmp0;
                    playerobj.Y = tmp1;
                    playerobj.GetLeft = tmp2;
                    playerobj.GetTop = tmp3;
                }
            }
        }

    }
}
