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

## Runner
Die Runner Klasse ist meine sogenannte Einstiegsklasse wo ich die passende Client/ Server hole und rufe die GetAsync Methode 
```cs
  public async Task StartAppAsync()
        {
            IWorker server = argsValidator.Validation(config["Servertype"], config["Port"]);
            server.Connect();

            myLogger.LogTrace("Connected ");
            await server.GetAsync();
        }
```	

## Server GetAsync
In der GetAsync Methode Serverseitig starte ich meine Listener auf die gegebenen port und accepte ich die einkommende Verbindungen. Danach kann ich die Networkstream von der TcpClient holen.

```cs
  while (isConnected)
            {
                if (stream.DataAvailable)
                {
                    byte[] receivedData = new byte[1024];
                    this.stream.Read(receivedData, 0, receivedData.Length);
                    string message = Encoding.UTF8.GetString(receivedData);
                    // TODO generate random chars
                    await SendAsync(Encoding.UTF8.GetBytes("You requested a random line of chars"));
                }
            }
```	

## Client GetAsync
Bei der Client erstelle ich eine TcpClient und verbinde ich mich auf die Localhost(127.0.0.1) auf den gegebenen Port. Nachdem kann der Kommunikation gestartet werden.
```cs
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
```	
