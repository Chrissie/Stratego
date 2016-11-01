using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using Stratego.Game;

namespace Stratego.Server
{
    class Server
    {
        private List<Player> players;

        public Server()
        {
            //SetUp();
        }

        public void SetUp()
        {
            TcpListener server = null;
            players = new List<Player>();
            Debug.WriteLine("In SetUp");
            try
            {
                Int32 port = 13000;
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(ip, port);
                server.Start();

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Debug.WriteLine("Connected!");
                    Thread thread = new Thread(HandleClient);
                    thread.Start(client);
                }
            }

            catch (SocketException e)
            {
                Debug.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
        }

        public void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();
            if (client.Connected)
            {
                byte[] data = new byte[400];
                stream.Read(data, 0, data.Length);
                string datatostring = Encoding.ASCII.GetString(data);
                dynamic json = JsonConvert.DeserializeObject(datatostring);
                Debug.WriteLine((string)json);

                string writes = JsonConvert.SerializeObject("string");
                byte[] bytes = Encoding.ASCII.GetBytes(writes);
                stream.Write(bytes, 0, bytes.Length);


                //stream.Close();
                //client.Close();
            }
        }

        
    }
}
