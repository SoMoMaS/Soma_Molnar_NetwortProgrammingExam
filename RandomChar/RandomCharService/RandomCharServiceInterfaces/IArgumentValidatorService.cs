//----------------------------------------------------------------------
// <copyright file="IArgumentValidatorService.cs" company="FHWN.ac.at">
// Copyright (c) FHWN. All rights reserved.
// </copyright>
// <summary></summary>
// <author>Soma Molnar</author>
// -----------------------------------------------------------------------

namespace RandomCharServiceInterfaces
{
    /// <summary>
    /// Defines the <see cref="IArgumentValidatorService" />.
    /// </summary>
    public interface IArgumentValidatorService
    {
        /// <summary>
        /// The Validation.
        /// </summary>
        /// <param name="connectionType">The connectionType<see cref="string"/>.</param>
        /// <param name="port">The port<see cref="string"/>.</param>
        /// <returns>The <see cref="IWorker"/>.</returns>
        IWorker Validation(string connectionType, string port);
    }
}
