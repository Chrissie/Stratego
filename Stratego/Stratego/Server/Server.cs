using Microsoft.CSharp.RuntimeBinder;
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
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;

namespace Stratego.Server
{
    class Server
    {
        public string lastinfo = "";
        public List<string> users = new List<string>();
        GameBoard ServerGameBoard = new GameBoard("serverboard");
        private bool player1ready = false;
        private bool player2ready = false;
        private Thread readythread;
        private Thread readythread2;

        private Cell[,] player1cells;
        private Cell[,] player2cells;

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

            while(client1.Connected && client2.Connected)
            {
                if (readythread == null)
                {
                    readythread = new Thread(HandleReady);
                    object objarray1 = new object[] { player1stream, 1 };
                    readythread.Start(objarray1);
                }
                else if (player1ready) readythread.Abort();

                if (readythread2 == null)
                {
                    readythread2 = new Thread(HandleReady);
                    object objarray2 = new object[] { player2stream, 2 };
                    readythread2.Start(objarray2);
                }
                else if (player2ready) readythread2.Abort();

                bool setup = true;
                bool player1turn = true;
                while (player1ready && player2ready)
                {
                    if (setup)
                    {
                        ServerGameBoard.board = player1cells;
                        GameBoard g = new GameBoard("player2", player2cells);
                        g.RotateBoard180();
                        player2cells = g.board;
                        ServerGameBoard.CreateFullGameBoard(player2cells);
                        string servergameboardstring = "";
                        using (MemoryStream ms = new MemoryStream())
                        {
                            ms.Seek(0, SeekOrigin.Begin);
                            SoapFormatter formatter = new SoapFormatter();
                            formatter.Serialize(ms, ServerGameBoard.board);
                            servergameboardstring = Encoding.UTF8.GetString(ms.ToArray());
                        }
                        WriteToClient(player1stream, "board-" + servergameboardstring);
                        ServerGameBoard.RotateBoard180();
                        servergameboardstring = "";
                        using (MemoryStream ms = new MemoryStream())
                        {
                            ms.Seek(0, SeekOrigin.Begin);
                            SoapFormatter formatter = new SoapFormatter();
                            formatter.Serialize(ms, ServerGameBoard.board);
                            servergameboardstring = Encoding.UTF8.GetString(ms.ToArray());
                        }
                        WriteToClient(player2stream, "board-" + servergameboardstring);
                    }
                    try
                    {
                        if (player1turn)
                        {
                            HandleTurn(player1stream, player2stream);
                        }
                        else
                        {
                            HandleTurn(player2stream, player1stream);
                        }
                        player1turn = !player1turn;
                    }
                    catch (IOException e)
                    {
                        Debug.WriteLine("A player disconnected " + e.Message);
                    }
                }
            }
           
            // Shutdown and end connection.
            client1.Close();
            client2.Close();
            Debug.WriteLine("Connection Closed");
        }

        public void HandleReady(object objects)
        {
            object[] streamandint = (object[])objects;
            NetworkStream playerstream = (NetworkStream)streamandint[0];
            int playerready = (int)streamandint[1];
            while (true)
            {
                dynamic Json = null;
                Json = ReadFromClient(playerstream);
                if (Json.ToString().StartsWith("Ready"))
                {
                    if (playerready == 1)
                    {
                        string boardstring = Json.ToString();
                        boardstring = Regex.Split(boardstring, "Ready-")[1];
                        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(boardstring)))
                        {
                            ms.Seek(0, SeekOrigin.Begin);
                            SoapFormatter formatter = new SoapFormatter();
                            player1cells = formatter.Deserialize(ms) as Cell[,];
                        }
                        player1ready = true;
                    }

                    if (playerready ==2)
                    {
                        string boardstring = Json.ToString();
                        boardstring = Regex.Split(boardstring, "Ready-")[1];
                        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(boardstring)))
                        {
                            ms.Seek(0, SeekOrigin.Begin);
                            SoapFormatter formatter = new SoapFormatter();
                            player2cells = formatter.Deserialize(ms) as Cell[,];
                        }
                        player2ready = true;
                    }
                    break;
                }
            }  
        }

        public void HandleTurn(NetworkStream player1, NetworkStream player2)
        {
            bool receivedBoard = false;
            dynamic Json = null;
            WriteToClient(player1, "yourturn");

            while (!receivedBoard)
            {
                Json = ReadFromClient(player1);
                if (Json.ToString().StartsWith("board"))
                {
                    receivedBoard = true;
                    Cell[,] cells;
                    string boardstring = (string)Json;
                    boardstring = Regex.Split(boardstring, "board-")[1];

                    using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(boardstring)))
                    {
                        ms.Seek(0, SeekOrigin.Begin);
                        SoapFormatter formatter = new SoapFormatter();
                        cells = formatter.Deserialize(ms) as Cell[,];
                    }
                    Thread.Sleep(2000);
                    //ServerGameBoard.board = cells;
                    ServerGameBoard = new GameBoard("server", cells);
                    ServerGameBoard.RotateBoard180();

                    string servergameboardstring = "";
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Seek(0, SeekOrigin.Begin);
                        SoapFormatter formatter = new SoapFormatter();
                        formatter.Serialize(ms, ServerGameBoard.board);
                        servergameboardstring = Encoding.UTF8.GetString(ms.ToArray());
                    }
                    WriteToClient(player2, "board-" + servergameboardstring);
                }
            }
            

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

        private static byte[] Read(NetworkStream Stream)
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
