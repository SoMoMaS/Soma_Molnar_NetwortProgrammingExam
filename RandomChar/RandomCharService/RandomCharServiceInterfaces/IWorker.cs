//----------------------------------------------------------------------
// <copyright file="IWorker.cs" company="FHWN.ac.at">
// Copyright (c) FHWN. All rights reserved.
// </copyright>
// <summary></summary>
// <author>Soma Molnar</author>
// -----------------------------------------------------------------------

namespace RandomCharServiceInterfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IWorker" />.
    /// </summary>
    public interface IWorker
    {
        /// <summary>
        /// The Connect.
        /// </summary>
        void Connect();

        /// <summary>
        /// The SendAsync.
        /// </summary>
        /// <param name="data">The data<see cref="byte[]"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SendAsync(byte[] data);

        /// <summary>
        /// The GetAsync.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        Task GetAsync();
    }
}
