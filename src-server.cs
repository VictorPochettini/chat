using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

class Program
{
    async Task HandleClientAsync(Socket client)
    {
        byte[] buffer = new byte[1024];
        while (true)
        {
            int bytesReceived = await client.ReceiveAsync(buffer, SocketFlags.None);
            string[3] pacote = (Encoding.UTF8.GetString(buffer, 0, bytesReceived)).split('#');

            string nome = pacote[1];
            string mensagem = pacote[2];
            string hora = pacote[3];

            Console.WriteLine($"{nome}: {mensagem}");


            await client.SendAsync(Encoding.UTF8.GetBytes($"Servidor: {message}"), SocketFlags.None);
        }
    }
    static async Task Main(String[] args)
    {
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 0);

        server.Bind(localEndPoint);

        int backlog = 15;

        server.Listen(backlog);

        try
        {
            while (true)
            {
                Socket client = await server.AcceptAsync();
                await HandleClientAsync(client);


            }
        }
        catch (SocketException e)
        {
            Console.WriteLine($"Falha ao aceitar cliente: {ex.Message}");
        }
        finally
        {
            server.Dispose();
        }
    }
}