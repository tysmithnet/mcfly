// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-11-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="InitMethod.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.Composition;

namespace McFly
{
    /// <summary>
    ///     McFly Method that will initialize a new project
    /// </summary>
    /// <seealso cref="McFly.IMcFlyMethod" />
    [Export(typeof(IMcFlyMethod))]
    [Export(typeof(InitMethod))]
    internal class InitMethod : IMcFlyMethod
    {
        /// <summary>
        ///     Processes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        public void Process(string[] args)
        {
            var options = ExtractOptions(args);
            var start = TimeTravelFacade.GetStartingPosition();
            var end = TimeTravelFacade.GetEndingPosition();
            ServerClient.InitializeProject(options.ProjectName, start, end);
        }

        /// <summary>
        ///     Extracts the options from the arguments
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>InitOptions.</returns>
        /// <exception cref="ArgumentNullException">args</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     args - InitMethod expects exactly 2 arguments, the --name switch and the
        ///     value
        /// </exception>
        internal InitOptions ExtractOptions(string[] args)
        {
            if (args == null) throw new ArgumentNullException(nameof(args));
            if (args.Length != 2)
                throw new ArgumentOutOfRangeException(nameof(args),
                    "InitMethod expects exactly 2 arguments, the --name switch and the value");
            return new InitOptions
            {
                ProjectName = args[1]
            };
        }

        /// <summary>
        ///     Gets the help information.
        /// </summary>
        /// <value>The help information.</value>
        public HelpInfo HelpInfo { get; } = new HelpInfoBuilder()
            .SetName("init")
            .SetDescription("Create a new project using the loaded trace file")
            .AddSwitch("-n, --name projectname", "Name of the project to create")
            .Build();

        /// <summary>
        ///     Gets or sets the debug eng proxy.
        /// </summary>
        /// <value>The debug eng proxy.</value>
        [Import]
        protected internal IDebugEngineProxy DebugEngineProxy { get; set; }

        /// <summary>
        ///     Gets or sets the server client.
        /// </summary>
        /// <value>The server client.</value>
        [Import]
        protected internal IServerClient ServerClient { get; set; }

        /// <summary>
        ///     Gets or sets the settings.
        /// </summary>
        /// <value>The settings.</value>
        [Import]
        protected internal Settings Settings { get; set; }

        /// <summary>
        ///     Gets or sets the time travel facade.
        /// </summary>
        /// <value>The time travel facade.</value>
        [Import]
        protected internal ITimeTravelFacade TimeTravelFacade { get; set; }
    }
}