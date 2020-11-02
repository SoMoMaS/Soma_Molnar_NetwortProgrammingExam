using RandomCharServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Server
{
    class ArgumentValidatorService : IArgumentValidatorService
    {
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
