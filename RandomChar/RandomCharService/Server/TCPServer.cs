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

        public Task GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task SendAsync()
        {
            throw new NotImplementedException();
        }
    }
}
