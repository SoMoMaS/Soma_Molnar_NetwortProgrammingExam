//----------------------------------------------------------------------
// <copyright company="FHWN.ac.at">
// Copyright (c) FHWN. All rights reserved.
// </copyright>
// <summary></summary>
// <author>Soma Molnar</author>
// -----------------------------------------------------------------------

namespace Server
{
    using RandomCharServiceInterfaces;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="TCPServer" />.
    /// </summary>
    class TCPServer : IWorker
    {
        /// <summary>
        /// Gets or sets the Port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Defines the client.
        /// </summary>
        private TcpClient client;

        /// <summary>
        /// Defines the listener.
        /// </summary>
        private TcpListener listener;

        /// <summary>
        /// Defines the stream.
        /// </summary>
        private NetworkStream stream;

        /// <summary>
        /// Defines the isConnected.
        /// </summary>
        private bool isConnected = false;

        /// <summary>
        /// The Connect.
        /// </summary>
        public void Connect()
        {
            this.listener = new TcpListener(IPAddress.Any, Port);
            this.listener.Start();
            this.client = this.listener.AcceptTcpClient();
            this.stream = this.client.GetStream();
            this.isConnected = true;
        }

        /// <summary>
        /// The GetAsync.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
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

        /// <summary>
        /// The SendAsync.
        /// </summary>
        /// <param name="data">The data<see cref="byte[]"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task SendAsync(byte[] data)
        {
            await this.stream.WriteAsync(data);
        }
    }
}
