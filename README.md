# Introduction
Diese Repository habe ich neu erstellt nachdem ich alle meine Veränderungen an dem Code irgendwie verloren habe. Ich bitte Sie um Verständis.
Ich habe den Code nur solange nachgebaut was ich bis 13:10 hatte.


# Input
Die Input erfolg durch den Command Line Arguments wie es in der Angabe steht. Server-und Clientseitig muss so angegeben werden: Servertype="Tcp/Udp" Port="portNumber".
Damit ich einfacher mit dem args arbeiten kann, füge die zum Konfiguration hinzu.

```cs
		.ConfigureAppConfiguration(appConf =>
                {
                    appConf.AddCommandLine(arguments);
                })
```

# Service 
Ich habe eine eigenes Service gebaut welche für die args Validation verantwortlich ist und beideseitig verwendbar ist.
```cs
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
```
Bei der Konfiguration des Hosts füge diese auch zur Services.
```cs
 .ConfigureServices(confServ =>
                {
                    confServ.AddTransient<IArgumentValidatorService, ArgumentValidatorService>();
                    confServ.AddTransient<Runner>();
                })
```
