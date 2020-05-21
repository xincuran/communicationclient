﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CommunicationClient
{
    class SendData
    {
        NetworkStream stream;

        void SendString(string msg, TcpClient client)
        {
            byte[] msgInBytes = Encoding.ASCII.GetBytes(msg);

            stream = client.GetStream();

            stream.Write(msgInBytes, 0, msgInBytes.Length);
        }

        public void KeepSend (TcpClient client)
        {
            while (true)
            {
                try
                {
                    string msg = Console.ReadLine();

                    SendString(msg, client);
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Error: {e}");
                }
            }
        }
    }
}
