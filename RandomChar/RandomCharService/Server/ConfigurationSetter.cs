using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RandomCharServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ConfigurationSetter
    {

        private IHost myHost;
        public async Task ConfigureHost(string[] arguments)
        {
            this.myHost = new HostBuilder()
                .ConfigureServices(confServ =>
                {
                    confServ.AddTransient<IArgumentValidatorService, ArgumentValidatorService>();
                })
                .ConfigureAppConfiguration(appConf =>
                {
                    appConf.AddCommandLine(arguments);
                })
                .ConfigureLogging(loggConf =>
               {
                   loggConf.AddDebug();
                   loggConf.AddConsole();
               }).Build();


        }
    }
}
