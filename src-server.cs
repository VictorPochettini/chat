using System;
using System.Net;
using System.Net.Sockets;

class Program
{
    async Task HandleClientAsync(Socket client)
    {
        byte[] buffer = new byte[1024];
        while (true)
        {
            int bytesReceived = await client.ReceiveAsync(buffer, SocketFlags.None);

            string message = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
            Console.WriteLine($"Recebido: {message}");


            await client.SendAsync(Encoding.UTF8.GetBytes($"Servidor: {message}"), SocketFlags.None);
        }
        client.Dispose();
    }
    static void Main(String[] args)
    {
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 0);

        s.Bind(localEndPoint);

        int backlog = 15;

        s.Listen(backlog);

        Socket client = await server.AcceptAsync();

    }
}