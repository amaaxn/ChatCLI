using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.Threading;

class ChatServer
{
    static List<TcpClient> clients = new List<TcpClient>();

    static void Main()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 6000);
        server.Start();
        Console.WriteLine("🚀 Server started on port 6000...");

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            clients.Add(client);
            Console.WriteLine("✅ New client connected!");

            Thread clientThread = new Thread(() => HandleClient(client));
            clientThread.Start();
        }
    }

    static void HandleClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead;

        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("📩 Received: " + message);

            // Broadcast message to all clients
            BroadcastMessage(message, client);
        }
    }

    static void BroadcastMessage(string message, TcpClient sender)
    {
        byte[] data = Encoding.ASCII.GetBytes(message);

        foreach (var client in clients)
        {
            if (client != sender) // Don't send the message back to the sender
            {
                client.GetStream().Write(data, 0, data.Length);
            }
        }
    }
}