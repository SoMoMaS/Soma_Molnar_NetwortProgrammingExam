using RandomCharServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class TCPClient : IWorker
    {
        public int Port { get; set; }
        private TcpClient client;
        private NetworkStream stream;
        public void Connect()
        {
            this.client = new TcpClient();
            this.client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port));
            this.stream = this.client.GetStream();
        }

        public Task GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task SendAsync(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
