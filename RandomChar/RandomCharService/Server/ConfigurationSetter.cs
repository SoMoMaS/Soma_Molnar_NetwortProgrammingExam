//----------------------------------------------------------------------
// <copyright file="ConfigurationSetter.cs" company="FHWN.ac.at">
// Copyright (c) FHWN. All rights reserved.
// </copyright>
// <summary></summary>
// <author>Soma Molnar</author>
// -----------------------------------------------------------------------

namespace Server
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using RandomCharServiceInterfaces;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ConfigurationSetter" />.
    /// </summary>
    public class ConfigurationSetter
    {
        /// <summary>
        /// Defines the myHost.
        /// </summary>
        private IHost myHost;

        /// <summary>
        /// The ConfigureHost.
        /// </summary>
        /// <param name="arguments">The arguments<see cref="string[]"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task ConfigureHost(string[] arguments)
        {
            this.myHost = new HostBuilder()
                .ConfigureServices(confServ =>
                {
                    confServ.AddTransient<IArgumentValidatorService, ArgumentValidatorService>();
                    confServ.AddTransient<Runner>();
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

            this.myHost.Start();

            var runner = this.myHost.Services.GetRequiredService<Runner>();

            await runner.StartAppAsync();
        }
    }
}
