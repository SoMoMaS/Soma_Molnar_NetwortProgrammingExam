Author: Soma Molnar
#Introduction
Diese Repository habe ich neu erstellt nachdem ich alle meine Veränderungen an dem Code irgendwie verloren habe. Ich bitte Sie um Verständis.
Ich habe den Code nur solange nachgebaut was ich bis 13:10 hatte.


#Input
Die Input erfolg durch den Command Line Arguments wie es in der Angabe steht. Server-und Clientseitig muss so angegeben werden: Servertype="Tcp/Udp" Port="portNumber".
Damit ich einfacher mit dem args arbeiten kann, füge die zum Konfiguration hinzu.
```cs
		.ConfigureAppConfiguration(appConf =>
                {
                    appConf.AddCommandLine(arguments);
                })
```


