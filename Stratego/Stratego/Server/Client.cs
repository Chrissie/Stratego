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
        string loginName;
        string ip;

        public Client(string ip = "localhost" , string loginName = "Client")
        {
            this.loginName = loginName;
            //this.ip = ip;

            try
            {
                int tries = 0;
                do
                {
                    Debug.WriteLine("Not connected");
                    ConnectServer(ip, "Connected");
                    tries++;
                } while (tries < 10 && !connected);

                if (connected)
                {
                    Debug.WriteLine("Client Connected");
                    Thread reader = new Thread(ReadFromServer);
                    reader.Start();
                   
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
                Debug.WriteLine("Send Client");
                connected = true;
                
            }
            catch (SocketException e)
            {
                Debug.WriteLine(e.StackTrace);
            }
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

        public void WriteFirstMessageToServer()
        {
            if (stream.CanWrite)
            {
                byte[] sendBytes = SendTunnel(loginName);
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
            Debug.WriteLine("Json length:" + jsonByte.Length);
            byte[] buffer = BitConverter.GetBytes(jsonByte.Length);

            byte[] messageToSend = new byte[buffer.Length + jsonByte.Length];
            Array.Copy(jsonByte, 0, messageToSend, buffer.Length, jsonByte.Length);
            Array.Copy(buffer, 0, messageToSend, 0, buffer.Length);
            return messageToSend;
        }

        private byte[] Read(NetworkStream Stream)
        {
            byte[] receiveBuffer = new byte[4];
            int size1 = (Stream.Read(receiveBuffer, 0, receiveBuffer.Length));
            int sizeSecond = BitConverter.ToInt32(receiveBuffer, 0);

            byte[] receiveBuffer2 = new byte[sizeSecond];
            byte[] completeBuffer = new byte[sizeSecond];
            int receivedBytes = 0;
            int totalBytes = 0;
            do
            {
                receivedBytes = Stream.Read(receiveBuffer2, 0, sizeSecond);
                Array.Copy(receiveBuffer2, 0, completeBuffer, totalBytes, receivedBytes);
                totalBytes += receivedBytes;
            } while (totalBytes < sizeSecond);
            return completeBuffer;
        }

    }
}
        
