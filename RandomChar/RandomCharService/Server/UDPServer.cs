using RandomCharServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class UDPServer : IWorker
    {
        public int Port { get; set; }
        public void Connect()
        {
            throw new NotImplementedException();
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
