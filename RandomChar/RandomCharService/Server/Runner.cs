using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RandomCharServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Runner
    {

        IArgumentValidatorService argsValidator;

        ILogger myLogger;

        IConfiguration config;

        public Runner(IArgumentValidatorService argsValidator, ILogger<Runner> myLogger, IConfiguration config)
        {
            this.argsValidator = argsValidator;
            this.myLogger = myLogger;
            this.config = config;
        }


        public async Task StartAppAsync()
        {
            IWorker server = argsValidator.Validation(config["Servertype"], config["Port"]);
            server.Connect();

            myLogger.LogTrace("Connected ");
            await server.GetAsync();

        }
    }
}
