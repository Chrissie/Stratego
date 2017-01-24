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
using System.Xml.Serialization;
using Stratego.Game;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.RegularExpressions;

namespace Stratego.Server
{
    public class Client
    {
        public bool Connected = false;
        TcpClient tcpClient;
        NetworkStream stream;
        public string LoginName;

        public Game.GameBoard PlayerBoard;
        public bool IsPlayersTurn = false;

        public Client(string ip = "localhost" , string loginName = "Client")
        {
            LoginName= loginName;
            PlayerBoard = new GameBoard(LoginName);
            try
            {
                int tries = 0;
                do
                {
                    Debug.WriteLine("Not Connected");
                    Debug.WriteLine(ip);

                    ConnectServer(ip, "Connected");
                    tries++;
                } while (tries < 10 && !Connected);

                if (Connected)
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
                if (!LoginName.Equals("Client"))
                {
                    LoginName = "Client-" + LoginName;
                }
                byte[] bytes = BuildMessage(LoginName);
                //stream.Write(bytes, 0, bytes.Length);
                Debug.WriteLine("Send Client");
                Connected = true;  
            }
            catch (SocketException e)
            {
                Debug.WriteLine(e.StackTrace);
            }
        }

        public void ReadFromServer(object obj)
        {
            int i = 0;
            while (Connected)
            {
                try
                {
                    if (stream.CanRead)
                    {
                        byte[] bytes = Read(stream);

                        string returnData = Encoding.ASCII.GetString(bytes);
                        Debug.WriteLine($"{LoginName}: Server returns: " + returnData);
                        if (returnData.StartsWith("chat"))
                        {
                            string chat = returnData.Split('-')[1];
                            Debug.WriteLine(chat);
                        }
                        if (returnData.StartsWith("board"))
                        {
                            string boardstring = Regex.Split(returnData, "board-")[1];

                            Cell[,] cells;
                            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(boardstring)))
                            {
                                ms.Seek(0, SeekOrigin.Begin);
                                SoapFormatter formatter = new SoapFormatter();
                                cells = formatter.Deserialize(ms) as Cell[,];
                            }
                            //PlayerBoard.board = cells;
                            PlayerBoard = new GameBoard($"{GetHashCode()}", cells);

                            Debug.WriteLine("Received new gameboard from server! " + PlayerBoard.ToString());
                        }
                        if (returnData.Equals("yourturn"))
                        {
                            IsPlayersTurn = true;
                            //SendGameBoard();
                        }
                    }
                }
                catch (IOException)
                {
                    Debug.WriteLine("Server disconnected");
                    stream.Close();
                    Connected = false;
                }
            }
        }

        public void WriteToServer(string toWrite)
        {
            byte[] bytestowrite = BuildMessage(toWrite);
            stream.Write(bytestowrite, 0, bytestowrite.Length);
        }

        public void WriteFirstMessageToServer()
        {
            if (stream.CanWrite)
            {
                byte[] sendBytes = SendTunnel(LoginName);
                stream.Write(sendBytes, 0, sendBytes.Length);
            }
            else
            {
                Debug.WriteLine("Cannot write data to stream");
                tcpClient.Close();
                stream.Close();
                Connected = false;
            }
        }

        public void SendReady()
        {
            string arraya = "Ready-";
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Seek(0, SeekOrigin.Begin);
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(ms, PlayerBoard.board);
                arraya += Encoding.UTF8.GetString(ms.ToArray());
            }
            byte[] tosend = BuildMessage(arraya);
            stream.Write(tosend, 0, tosend.Length);
        }

        public void SendGameBoard()
        {
            string arraya = "board-";
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Seek(0, SeekOrigin.Begin);
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(ms, PlayerBoard.board);
                arraya += Encoding.UTF8.GetString(ms.ToArray());
            }
            byte[] tosend = BuildMessage(arraya);
            stream.Write(tosend, 0, tosend.Length);
            IsPlayersTurn = false;
        }

        public byte[] SendTunnel(dynamic command)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            return BuildMessage(JsonConvert.SerializeObject(command, settings));
        }

        public byte[] SendTunnel(string prefix, dynamic command)
        {
            byte[] prefixbytes = BuildMessage(prefix);
            byte[] objectbytes = BuildMessage(JsonConvert.SerializeObject(command));
            Array.Copy(prefixbytes, 0, objectbytes, 0, prefixbytes.Length);
            return objectbytes;
        }

        public byte[] BuildMessage(string s)
        {
            byte[] jsonByte = Encoding.Default.GetBytes(s);
            //Debug.WriteLine("Json length:" + jsonByte.Length);
            byte[] buffer = BitConverter.GetBytes(jsonByte.Length);

            byte[] messageToSend = new byte[buffer.Length + jsonByte.Length];
            Array.Copy(jsonByte, 0, messageToSend, buffer.Length, jsonByte.Length);
            Array.Copy(buffer, 0, messageToSend, 0, buffer.Length);
            Debug.WriteLine($"MessagetoSend: {messageToSend}");
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
        
