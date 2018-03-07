// ***********************************************************************
// Assembly         : mcfly
// Author           : master
// Created          : 03-03-2018
//
// Last Modified By : master
// Last Modified On : 03-04-2018
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
    ///     Class McFlyApp.
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