﻿using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Stratego.Game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace Stratego.Server
{
    class Server
    {
        public string lastinfo = "";
        public List<string> users = new List<string>();

        public Server()
        {
            Thread setupthread = new Thread(SetUp);
            setupthread.Start();
        }

        public void SetUp()
        {
            TcpListener server = null;

            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                int i = 0;
                // Enter the listening loop.
                while (users.Count <= 10)
                {
                    object[] clientsAsObjArray = new object[2];
                    Debug.Write("Waiting for a connection... ");

                    TcpClient client1 = server.AcceptTcpClient();
                    clientsAsObjArray[0] = client1;
                    Debug.WriteLine("Accepted Client1");

                    TcpClient client2 = server.AcceptTcpClient();
                    clientsAsObjArray[1] = client2;
                    Debug.WriteLine("Accepted Client2");

                    Debug.WriteLine("Connected!");
                    // Handle 2 clients in their own thread
                    Thread thread = new Thread(HandleTwoClients);
                    thread.Start(clientsAsObjArray);
                }
            }
            catch (SocketException e)
            {
                Debug.WriteLine("SocketException: {0}", e);
            }
            catch (IOException e)
            {
                Debug.WriteLine($"IOException: {e}");
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
        }

        public void HandleTwoClients(object obj)
        {
            object[] clients = (object[])obj;
            TcpClient client1 = (TcpClient)clients[0];
            TcpClient client2 = (TcpClient)clients[1];

            Debug.WriteLine("Got two clients succesfully in 1 thread!!!");

            NetworkStream player1stream = client1.GetStream();
            NetworkStream player2stream = client2.GetStream();

            GameBoard ServerGameBoard = new GameBoard("serverboard");
            if (client1.Connected)
            {
                // Read the login name from the client.
                string login = ReadFirstMessage(player1stream);
                lastinfo = login;
                users.Add(login);
                Debug.WriteLine("Login: " + login);
            }
            if (client2.Connected)
            {
                // Read the login name from the client.
                string login = ReadFirstMessage(player2stream);
                lastinfo = login;
                users.Add(login);
                Debug.WriteLine("Login: " + login);
            }

            bool player1turn = true;

            while (client1.Connected && client2.Connected)
            {
                // Wait for a message from the client and stay blocked until then.
                dynamic Json = null;
                try
                {
                    if (player1turn)
                    {
                        WriteToClient(player1stream, "yourturn");
                        Json = ReadFromClient(player1stream);
                        Cell[,] cells;
                        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(Json)))
                        {
                            SoapFormatter formatter = new SoapFormatter();
                            cells = formatter.Deserialize(ms) as Cell[,];
                        }
                        Thread.Sleep(2000);
                        ServerGameBoard.board = cells;
                        ServerGameBoard.RotateBoard180();

                        string arrayasstring = "";
                        using (MemoryStream ms = new MemoryStream())
                        {
                            SoapFormatter formatter = new SoapFormatter();
                            formatter.Serialize(ms, ServerGameBoard.board);
                            arrayasstring = Encoding.UTF8.GetString(ms.ToArray());
                        }
                        byte[] tosend1 = BuildMessage("board");
                        player2stream.Write(tosend1, 0, tosend1.Length);

                        byte[] tosend2 = BuildMessage(arrayasstring);
                        player1stream.Write(tosend2, 0, tosend2.Length);
                        WriteToClient(player2stream, Json);
                        player1turn = !player1turn;
                    }
                    else
                    {
                        WriteToClient(player2stream, "yourturn");
                        Json = ReadFromClient(player2stream);
                        Cell[,] cells;
                        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(Json)))
                        {
                            SoapFormatter formatter = new SoapFormatter();
                            cells = formatter.Deserialize(ms) as Cell[,];
                        }
                        Thread.Sleep(2000);
                        GameBoard NewGameBoard = new GameBoard("lmao");
                        NewGameBoard.board = cells;
                        ServerGameBoard.CreateFullGameBoard(NewGameBoard);
                        ServerGameBoard.RotateBoard180();

                        string arrayasstring = "";
                        using (MemoryStream ms = new MemoryStream())
                        {
                            SoapFormatter formatter = new SoapFormatter();
                            formatter.Serialize(ms, ServerGameBoard.board);
                            arrayasstring = Encoding.UTF8.GetString(ms.ToArray());
                        }
                        byte[] tosend1 = BuildMessage("board");
                        player2stream.Write(tosend1, 0, tosend1.Length);

                        byte[] tosend2 = BuildMessage(arrayasstring);
                        player2stream.Write(tosend2, 0, tosend2.Length);
                        WriteToClient(player1stream, Json);
                        player1turn = !player1turn;
                    }

                }
                catch (IOException e)
                {
                    Debug.WriteLine("A player disconnected " + e.Message);
                }
                //catch (RuntimeBinderException)
                //{
                //    Debug.WriteLine("Client disconnected because runtimebinder ");
                //    client1.Close();
                //    client2.Close();
                //}
            }

            // Shutdown and end connection.
            client1.Close();
            client2.Close();
            Debug.WriteLine("Connection Closed");
        }

        // Read from the Stream.
        public dynamic ReadFromClient(NetworkStream Stream)
        {
            byte[] completeBuffer = Read(Stream);
            return ByteToDynamic(completeBuffer);
        }

        private void WriteToClient(NetworkStream stream, string message)
        {
            Debug.WriteLine($"Server: Writing message {message} to a stream");
            byte[] buffer = BuildMessage(message);
            stream.Write(buffer, 0, buffer.Length);
        }

        // Convert byte[] to dynamic.
        public dynamic ByteToDynamic(byte[] array)
        {
            StringBuilder stringbuilder = new StringBuilder();
            stringbuilder.AppendFormat("{0}", Encoding.ASCII.GetString(array, 0, array.Length));
            //return JsonConvert.DeserializeObject(stringbuilder.ToString());
            return stringbuilder.ToString();
        }

        // Read the first message from the stream wich is a string.
        public string ReadFirstMessage(NetworkStream Stream)
        {
            Debug.WriteLine("Server: Reading Login");
            byte[] completeBuffer = Read(Stream);
            StringBuilder stringbuilder = new StringBuilder();
            stringbuilder.AppendFormat("{0}", Encoding.ASCII.GetString(completeBuffer, 0, completeBuffer.Length));
            Debug.WriteLine($"Server: Finished Login Read: {stringbuilder.ToString()}");
            return stringbuilder.ToString();
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

        public byte[] BuildMessage(string s)
        {
            byte[] messageByte = Encoding.Default.GetBytes(s);
            byte[] buffer = BitConverter.GetBytes(messageByte.Length);

            byte[] messageToSent = new byte[buffer.Length + messageByte.Length];
            Array.Copy(messageByte, 0, messageToSent, buffer.Length, messageByte.Length);
            Array.Copy(buffer, 0, messageToSent, 0, buffer.Length);
            return messageToSent;
        }
    }
}
