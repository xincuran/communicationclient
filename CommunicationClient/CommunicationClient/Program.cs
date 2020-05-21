using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CommunicationClient
{
    class Program
    {
        static string ipAddress = "192.168.0.104";
        static int port = 26950;

        static SendData dataSender = new SendData();
        static RecieveData dataReciever = new RecieveData();
        static TcpClient client;

        static void Main(string[] args)
        {
            Console.Title = "Comm. Basic";

            try
            {
                client = new TcpClient();
                client.Connect(IPAddress.Parse(ipAddress), port);

                NetworkStream stream;

                stream = client.GetStream();

                ThreadStart job = new ThreadStart(ThreadSend);
                Thread thread = new Thread(job);
                thread.Start();

                dataReciever.KeepRecieve(client);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e}");
            }

            Console.ReadKey();
        }

        static void ThreadSend()
        {
            dataSender.KeepSend(client);
        }
    }
}
