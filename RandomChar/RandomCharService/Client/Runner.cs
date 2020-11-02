//----------------------------------------------------------------------
// <copyright company="FHWN.ac.at">
// Copyright (c) FHWN. All rights reserved.
// </copyright>
// <summary></summary>
// <author>Soma Molnar</author>
// -----------------------------------------------------------------------

namespace Client
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using RandomCharServiceInterfaces;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="Runner" />.
    /// </summary>
    public class Runner
    {
        /// <summary>
        /// Defines the argsValidator.
        /// </summary>
        IArgumentValidatorService argsValidator;

        /// <summary>
        /// Defines the myLogger.
        /// </summary>
        ILogger myLogger;

        /// <summary>
        /// Defines the config.
        /// </summary>
        IConfiguration config;

        /// <summary>
        /// Initializes a new instance of the <see cref="Runner"/> class.
        /// </summary>
        /// <param name="argsValidator">The argsValidator<see cref="IArgumentValidatorService"/>.</param>
        /// <param name="myLogger">The myLogger<see cref="ILogger{Runner}"/>.</param>
        /// <param name="config">The config<see cref="IConfiguration"/>.</param>
        public Runner(IArgumentValidatorService argsValidator, ILogger<Runner> myLogger, IConfiguration config)
        {
            this.argsValidator = argsValidator;
            this.myLogger = myLogger;
            this.config = config;
        }

        /// <summary>
        /// The StartAppAsync.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task StartAppAsync()
        {
            IWorker server = argsValidator.Validation(config["Servertype"], config["Port"]);
            server.Connect();

            myLogger.LogDebug("Connected ");
            await server.GetAsync();
        }
    }
}
