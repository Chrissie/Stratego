using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.IO;

namespace Stratego.Server
{
    class Client
    {
        bool connected = false;
        TcpClient tcpClient;
        NetworkStream stream;
        string loginName = "";

        public Client(string ip = "localhost" , string loginName = "Client")
        {
            try
            {
                int tries = 0;
                do
                {
                    Console.WriteLine("Not connected");
                    ConnectServer(ip, "Connected");
                    tries++;
                } while (tries < 10 && !connected);

                if (connected)
                {
                    Debug.WriteLine("Client Connected");
                    Thread reader = new Thread(ReadFromServer);
                    reader.Start();
                    Thread writer = new Thread(UpdateToServer);
                    writer.Start();

                    WriteFirstMessageToServer();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
            }
        }

        public void ConnectServer(string server, string message)
        {
            try
            {
                Int32 port = 13000;
                tcpClient = new TcpClient(server, port);
                // Identify to the server as a client
                stream = tcpClient.GetStream();
                if (!loginName.Equals("Client"))
                {
                    loginName = "Client-" + loginName;
                }
                byte[] bytes = BuildMessage(loginName);
                stream.Write(bytes, 0, bytes.Length);
                Console.WriteLine("Send Client");
                connected = true;
                
            }
            catch (SocketException e)
            {
                Debug.WriteLine(e.StackTrace);
            }
        }

        public static void SetUp(object obj)
        {
            TcpListener server = null;
            try
            {
                Debug.WriteLine("In try");
                Int32 port = 13000;
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(ip, port);
                server.Start();

                while (true)
                {
                    Debug.WriteLine("in while");
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

        public static void HandleClient(object obj)
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


                //client.Close();
            }
            stream.Close();
        }

        public void ReadFromServer(object obj)
        {
            while (connected)
            {
                try
                {
                    if (stream.CanRead)
                    {
                        byte[] bytes = Read(stream);

                        string returnData = Encoding.ASCII.GetString(bytes);
                        Debug.WriteLine("Host returns: " + returnData);
                        if (returnData.StartsWith("chat"))
                        {

                        }
                    }
                }
                catch (IOException e)
                {
                    Debug.WriteLine("Server disconnected");
                    stream.Close();
                    connected = false;
                }
            }
        }


        public void UpdateToServer(object obj)
        {
            
        }

        public void WriteFirstMessageToServer()
        {
            //stream = tcpClient.GetStream();
            //Console.WriteLine("We {0} write", stream.CanWrite);
            if (stream.CanWrite)
            {
                //byte[] sendBytes = ObjectToByteArray(measurement);
                byte[] sendBytes = SendTunnel(loginName);
                //Console.WriteLine("Message Lenght " + sendBytes.Length);
                stream.Write(sendBytes, 0, sendBytes.Length);
            }
            else
            {
                Debug.WriteLine("Cannot write data to stream");
                tcpClient.Close();
                stream.Close();
                connected = false;
            }
        }

        public byte[] SendTunnel(dynamic command)
        {
            return BuildMessage(JsonConvert.SerializeObject(command));
        }

        public byte[] BuildMessage(string s)
        {
            byte[] jsonByte = Encoding.Default.GetBytes(s);
            Console.WriteLine("Json length:" + jsonByte.Length);
            byte[] buffer = BitConverter.GetBytes(jsonByte.Length);

            byte[] messageToSend = new byte[buffer.Length + jsonByte.Length];
            Array.Copy(jsonByte, 0, messageToSend, buffer.Length, jsonByte.Length);
            Array.Copy(buffer, 0, messageToSend, 0, buffer.Length);
            return messageToSend;
        }

        private Byte[] Read(NetworkStream Stream)
        {
            Byte[] receiveBuffer = new Byte[4];
            int size1 = (Stream.Read(receiveBuffer, 0, receiveBuffer.Length));
            int sizeSecond = BitConverter.ToInt32(receiveBuffer, 0);

            Byte[] receiveBuffer2 = new Byte[sizeSecond];
            Byte[] completeBuffer = new Byte[sizeSecond];
            int receivedBytes = 0;
            int totalBytes = 0;
            do
            {
                receivedBytes = Stream.Read(receiveBuffer2, 0, sizeSecond);
                System.Array.Copy(receiveBuffer2, 0, completeBuffer, totalBytes, receivedBytes);
                totalBytes += receivedBytes;
            } while (totalBytes < sizeSecond);
            return completeBuffer;
        }


    }
}
        
