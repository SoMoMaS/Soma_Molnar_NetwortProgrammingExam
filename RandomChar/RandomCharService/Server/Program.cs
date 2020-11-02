using System;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var hostConfig = new ConfigurationSetter();
            await hostConfig.ConfigureHost(args);
        }
    }
}
