//----------------------------------------------------------------------
// <copyright company="FHWN.ac.at">
// Copyright (c) FHWN. All rights reserved.
// </copyright>
// <summary></summary>
// <author>Soma Molnar</author>
// -----------------------------------------------------------------------

namespace Client
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
                var udpClient = new UDPClient();

                if (isValidPort)
                {
                    udpClient.Port = Port;
                }
                else
                {
                    udpClient.Port = 80;
                }

                return udpClient;
            }
            else if (connectionType == "Tcp")
            {
                var tcpClient = new TCPClient();

                if (isValidPort)
                {
                    tcpClient.Port = Port;
                }
                else
                {
                    tcpClient.Port = 80;
                }

                return tcpClient;
            }
            else
            {
                return null;
            }
        }
    }
}
