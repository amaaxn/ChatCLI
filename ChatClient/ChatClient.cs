using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class ChatClient
{
    static void Main()
    {
        Console.Write("Enter your name: ");
        string username = Console.ReadLine();

        TcpClient client = new TcpClient("172.24.83.24", 6000);
        NetworkStream stream = client.GetStream();
        Console.WriteLine("✅ Connected to the server!");

        // Start a thread to listen for incoming messages
        Thread receiveThread = new Thread(() => ReceiveMessages(client));
        receiveThread.Start();

        while (true)
        {
            string message = Console.ReadLine();
            string formattedMessage = $"{username}: {message}";
            byte[] data = Encoding.ASCII.GetBytes(formattedMessage);
            stream.Write(data, 0, data.Length);
        }
    }

    static void ReceiveMessages(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead;

        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("\n📩 " + message);
        }
    }
}