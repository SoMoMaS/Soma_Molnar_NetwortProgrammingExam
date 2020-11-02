using RandomCharServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class ArgumentValidatorService : IArgumentValidatorService
    {
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
                var tcpClient= new TCPClient();

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
