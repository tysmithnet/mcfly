// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="McFlyApp.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.Composition;

namespace McFly
{
    /// <summary>
    ///     The root of all client side functionality
    /// </summary>
    /// <seealso cref="McFly.IInjectable" />
    [Export]
    internal class McFlyApp : IInjectable
    {
        /// <summary>
        ///     Gets or sets the mc fly methods.
        /// </summary>
        /// <value>The mc fly methods.</value>
        [ImportMany]
        public IMcFlyMethod[] McFlyMethods { get; set; }
    }
}