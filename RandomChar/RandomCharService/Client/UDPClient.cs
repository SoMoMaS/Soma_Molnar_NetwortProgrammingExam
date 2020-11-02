//----------------------------------------------------------------------
// <copyright file="UDPClient.cs" company="FHWN.ac.at">
// Copyright (c) FHWN. All rights reserved.
// </copyright>
// <summary></summary>
// <author>Soma Molnar</author>
// -----------------------------------------------------------------------

namespace Client
{
    using RandomCharServiceInterfaces;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="UDPClient" />.
    /// </summary>
    class UDPClient : IWorker
    {
        /// <summary>
        /// Gets or sets the Port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The Connect.
        /// </summary>
        public void Connect()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetAsync.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        public Task GetAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The SendAsync.
        /// </summary>
        /// <param name="data">The data<see cref="byte[]"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public Task SendAsync(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
