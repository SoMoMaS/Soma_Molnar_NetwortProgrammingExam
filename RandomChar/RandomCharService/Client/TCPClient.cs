using RandomCharServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class TCPClient : IWorker
    {
        public int Port { get; set; }
        private bool isConnected;
        private TcpClient client;
        private NetworkStream stream;
        public void Connect()
        {
            this.client = new TcpClient();
            this.client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port));
            this.stream = this.client.GetStream();
            this.isConnected = true;
        }

        public async Task GetAsync()
        {
            while (this.isConnected)
            {
                if (this.stream.DataAvailable)
                {
                    byte[] reveivedData = new byte[1024];
                    this.stream.Read(reveivedData, 0, reveivedData.Length);
                    Console.WriteLine(Encoding.UTF8.GetString(reveivedData));
                }
                Console.WriteLine("Type 'GetRand' to get a random line of chars.");
                string message = Console.ReadLine();
                byte[] messageToSend = Encoding.UTF8.GetBytes(message);
                await SendAsync(messageToSend);
            }
        }

        public async Task SendAsync(byte[] data)
        {
            await this.stream.WriteAsync(data, 0, data.Length);
        }
    }
}
