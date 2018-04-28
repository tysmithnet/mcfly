// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-25-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-25-2018
// ***********************************************************************
// <copyright file="HelpInfo.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;

namespace McFly.WinDbg
{
    /// <summary>
    ///     All IMcFly methods must use this type to register their help text
    /// <remarks>
    /// Switches are things like -a -b -c --all --basic --copy. 
    /// Subcommands are akin to git add, git commit, git push
    /// </remarks>
    /// </summary>
    public sealed class HelpInfo
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="HelpInfo" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="switches">The switches.</param>
        /// <param name="examples">The examples.</param>
        /// <param name="subcommands">The subcommands.</param>
        /// <exception cref="ArgumentNullException">
        ///     name
        ///     or
        ///     description
        /// </exception>
        public HelpInfo(string name, string description, Dictionary<string, string> switches,
            Dictionary<string, string> examples, HelpInfo[] subcommands)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Switches = switches ?? new Dictionary<string, string>();
            Examples = examples ?? new Dictionary<string, string>();
            Subcommands = subcommands ?? new HelpInfo[0];
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HelpInfo" /> class.
        /// </summary>
        internal HelpInfo()
        {
        }

        /// <summary>
        ///     Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; internal set; }

        /// <summary>
        ///     Gets the examples.
        /// </summary>
        /// <value>The examples.</value>
        public Dictionary<string, string> Examples { get; internal set; }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; internal set; }

        /// <summary>
        ///     Gets the subcommands.
        /// </summary>
        /// <value>The subcommands.</value>
        public HelpInfo[] Subcommands { get; internal set; }

        /// <summary>
        ///     Gets the switches.
        /// </summary>
        /// <value>The switches.</value>
        public Dictionary<string, string> Switches { get; internal set; }
    }
}