using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CommunicationClient
{
    class RecieveData
    {
        NetworkStream stream;

        void RecieveString(TcpClient client)
        {
            stream = client.GetStream();

            byte[] bytes = new byte[1024];
            int bytesRead = stream.Read(bytes, 0, bytes.Length);

            string recievedMsg = Encoding.ASCII.GetString(bytes, 0, bytesRead);
            Console.WriteLine($"Message from Server: " + recievedMsg);

        } 

        public void KeepRecieve(TcpClient client)
        {
            while (true)
            {
                try
                {
                    RecieveString(client);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e}");
                }
            }
        }
    }
}
