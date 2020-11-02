//----------------------------------------------------------------------
// <copyright file="ArgumentValidatorService.cs" company="FHWN.ac.at">
// Copyright (c) FHWN. All rights reserved.
// </copyright>
// <summary></summary>
// <author>Soma Molnar</author>
// -----------------------------------------------------------------------

namespace Server
{
    using RandomCharServiceInterfaces;
    using System;

    /// <summary>
    /// Defines the <see cref="ArgumentValidatorService" />.
    /// </summary>
    class ArgumentValidatorService : IArgumentValidatorService
    {
        /// <summary>
        /// The Validation.
        /// </summary>
        /// <param name="connectionType">The connectionType<see cref="string"/>.</param>
        /// <param name="port">The port<see cref="string"/>.</param>
        /// <returns>The <see cref="IWorker"/>.</returns>
        public IWorker Validation(string connectionType, string port)
        {
            int Port;
            bool isValidPort = Int32.TryParse(port, out Port);

            if (connectionType == "Udp")
            {
                var udpServer = new UDPServer();

                if (isValidPort)
                {
                    udpServer.Port = Port;
                }
                else
                {
                    udpServer.Port = 80;
                }

                return udpServer;
            }
            else if (connectionType == "Tcp")
            {
                var tcpServer = new TCPServer();

                if (isValidPort)
                {
                    tcpServer.Port = Port;
                }
                else
                {
                    tcpServer.Port = 80;
                }

                return tcpServer;
            }
            else
            {
                return null;
            }
        }
    }
}
