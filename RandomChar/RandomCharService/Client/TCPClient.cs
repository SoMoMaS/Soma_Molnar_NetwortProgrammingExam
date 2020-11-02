//----------------------------------------------------------------------
// <copyright file="TCPClient.cs" company="FHWN.ac.at">
// Copyright (c) FHWN. All rights reserved.
// </copyright>
// <summary></summary>
// <author>Soma Molnar</author>
// -----------------------------------------------------------------------

namespace Client
{
    using RandomCharServiceInterfaces;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="TCPClient" />.
    /// </summary>
    class TCPClient : IWorker
    {
        /// <summary>
        /// Gets or sets the Port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Defines the isConnected.
        /// </summary>
        private bool isConnected;

        /// <summary>
        /// Defines the client.
        /// </summary>
        private TcpClient client;

        /// <summary>
        /// Defines the stream.
        /// </summary>
        private NetworkStream stream;

        /// <summary>
        /// The Connect.
        /// </summary>
        public void Connect()
        {
            this.client = new TcpClient();
            this.client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port));
            this.stream = this.client.GetStream();
            this.isConnected = true;
        }

        /// <summary>
        /// The GetAsync.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
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

        /// <summary>
        /// The SendAsync.
        /// </summary>
        /// <param name="data">The data<see cref="byte[]"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task SendAsync(byte[] data)
        {
            await this.stream.WriteAsync(data, 0, data.Length);
        }
    }
}
