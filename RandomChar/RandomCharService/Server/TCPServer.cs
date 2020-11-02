using RandomCharServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class TCPServer : IWorker
    {
        public int Port { get; set; }

        private TcpClient client;
        private TcpListener listener;
        private NetworkStream stream;

        private bool isConnected = false;

        public void Connect()
        {
            this.listener = new TcpListener(IPAddress.Any, Port);
            this.listener.Start();
            this.client = this.listener.AcceptTcpClient();
            this.stream = this.client.GetStream();
            this.isConnected = true;

        }

        public async Task GetAsync()
        {
            while (isConnected)
            {
                if (stream.DataAvailable)
                {
                    byte[] receivedData = new byte[1024];
                    this.stream.Read(receivedData, 0, receivedData.Length);
                    string message = Encoding.UTF8.GetString(receivedData);
                    // TODO generate random chars
                    /*if (message == "GetRand")
                    {
                        

                        await SendAsync(Encoding.UTF8.GetBytes("You requested a random line of chars"));
                    }*/

                    await SendAsync(Encoding.UTF8.GetBytes("You requested a random line of chars"));
                }
            }
        }

        public async Task SendAsync(byte[] data)
        {
            await this.stream.WriteAsync(data);
        }
    }
}
