using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

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
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (IOException e)
            {
                Console.WriteLine($"IOException: {e}");
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

            // Get a stream object for reading and writing.
            NetworkStream Stream = client1.GetStream();
            if (client1.Connected)
            {
                // Read the login name from the client.
                string login = ReadFirstMessage(Stream);
                lastinfo = login;
                users.Add(login);
                Debug.WriteLine("Login: " + login);

            }
            while (client1.Connected)
            {
                // Wait for a message from the client and stay blocked until then.
                dynamic Json = null;
                try
                {
                    //Json = ReadFromClient(Stream);
                   
                }
                catch (IOException e)
                {
                    Console.WriteLine("Client disconnected " + e.Message);

                }
                catch (RuntimeBinderException)
                {
                    Console.WriteLine("Client disconnected ");
                    client1.Close();
                }
            }

            // Shutdown and end connection.
            client1.Close();
            Console.WriteLine("Connection Closed");
        }

        // Read from the Stream.
        public dynamic readFromClient(NetworkStream Stream)
        {
            //Console.WriteLine("Reading from client");
            Byte[] completeBuffer = Read(Stream);
            return ByteToDynamic(completeBuffer);
        }

        // Convert byte[] to dynamic.
        public dynamic ByteToDynamic(Byte[] array)
        {
            StringBuilder stringbuilder = new StringBuilder();
            stringbuilder.AppendFormat("{0}", Encoding.ASCII.GetString(array, 0, array.Length));
            return JsonConvert.DeserializeObject(stringbuilder.ToString());
        }

        // Read the first message from the stream wich is a string.
        public string ReadFirstMessage(NetworkStream Stream)
        {
            Console.WriteLine("Reading Login");
            Byte[] completeBuffer = Read(Stream);
            StringBuilder stringbuilder = new StringBuilder();
            stringbuilder.AppendFormat("{0}", Encoding.ASCII.GetString(completeBuffer, 0, completeBuffer.Length));
            return stringbuilder.ToString();
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

        // Read from the Stream.
        public dynamic ReadFromClient(NetworkStream Stream)
        {
            Byte[] completeBuffer = Read(Stream);
            return ByteToDynamic(completeBuffer);
        }
    }
}
