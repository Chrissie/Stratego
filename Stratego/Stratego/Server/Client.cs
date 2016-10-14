using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Stratego.Server
{
    class Client
    {
        public Client()
        {
            Connect("127.0.0.1", 13000, "Hello");
        }

        public void Connect(string ip, Int32 port, string message)
        {
            try
            {
                TcpClient client = new TcpClient(ip, port);
                NetworkStream stream = client.GetStream();
                
                string json = JsonConvert.SerializeObject(message);
                byte[] data = Encoding.ASCII.GetBytes(json);
                stream.Write(data, 0, data.Length);
                
                data = new Byte[256];
                int bytes = stream.Read(data, 0, data.Length);
                string responsedata = (string) JsonConvert.DeserializeObject(Encoding.ASCII.GetString(data, 0, bytes));
                Debug.Write(responsedata);

                //stream.Close();
                //client.Close();
            }
            catch (ArgumentNullException e)
            {
                Debug.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Debug.WriteLine("SocketException: {0}", e);
            }
        }
    }
}
        
