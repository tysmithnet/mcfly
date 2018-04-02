// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 03-31-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-01-2018
// ***********************************************************************
// <copyright file="ContextFactory.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel.Composition;
using System.Data.SqlClient;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Class ContextFactory.
    /// </summary>
    /// <seealso cref="McFly.Server.Data.SqlServer.IContextFactory" />
    [Export(typeof(IContextFactory))]
    internal class ContextFactory : IContextFactory
    {
        /// <summary>
        ///     Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
        [Import]
        protected internal Settings Settings { get; set; }

        /// <summary>
        ///     Gets the context.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <returns>IMcFlyContext.</returns>
        public IMcFlyContext GetContext(string projectName)
        {
            var builder =
                new SqlConnectionStringBuilder(Settings.ConnectionString ?? "")
                {
                    InitialCatalog = $"mcfly_{projectName}"
                };
            return new McFlyContext(builder.ToString());
        }
    }
}