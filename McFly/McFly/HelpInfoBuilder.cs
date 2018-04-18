// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-25-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="HelpInfoBuilder.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;

namespace McFly
{
    /// <summary>
    ///     Class HelpInfoBuilder.
    /// </summary>
    public class HelpInfoBuilder
    {
        /// <summary>
        ///     The information
        /// </summary>
        private readonly HelpInfo _info;

        /// <summary>
        ///     Initializes a new instance of the <see cref="HelpInfoBuilder" /> class.
        /// </summary>
        public HelpInfoBuilder()
        {
            _info = new HelpInfo();
            _info.Examples = new Dictionary<string, string>();
            _info.Subcommands = new HelpInfo[0];
            _info.Switches = new Dictionary<string, string>();
        }

        /// <summary>
        ///     Sets the name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>HelpInfoBuilder.</returns>
        public HelpInfoBuilder SetName(string name)
        {
            _info.Name = name;
            return this;
        }

        /// <summary>
        ///     Sets the description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>HelpInfoBuilder.</returns>
        public HelpInfoBuilder SetDescription(string description)
        {
            _info.Description = description;
            return this;
        }

        /// <summary>
        ///     Adds the switch.
        /// </summary>
        /// <param name="switch">The switch.</param>
        /// <param name="description">The description.</param>
        /// <returns>HelpInfoBuilder.</returns>
        public HelpInfoBuilder AddSwitch(string @switch, string description)
        {
            if (!_info.Switches.ContainsKey(@switch))
                _info.Switches.Add(@switch, description);
            else
                _info.Switches[@switch] = description;
            return this;
        }

        /// <summary>
        ///     Adds the subcommand.
        /// </summary>
        /// <param name="subcommand">The subcommand.</param>
        /// <returns>HelpInfoBuilder.</returns>
        public HelpInfoBuilder AddSubcommand(HelpInfo subcommand)
        {
            var list = _info.Subcommands.ToList();
            var existing = list.FirstOrDefault(x => x.Name == subcommand.Name);
            if (existing != null)
                list.Remove(existing);
            list.Add(subcommand);
            _info.Subcommands = list.OrderBy(x => x.Name).ToArray();
            return this;
        }

        /// <summary>
        ///     Adds the example.
        /// </summary>
        /// <param name="example">The example.</param>
        /// <param name="description">The description.</param>
        /// <returns>HelpInfoBuilder.</returns>
        public HelpInfoBuilder AddExample(string example, string description)
        {
            if (!_info.Examples.ContainsKey(example))
                _info.Examples.Add(example, description);
            else
                _info.Examples[example] = description;
            return this;
        }

        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns>HelpInfo.</returns>
        public HelpInfo Build()
        {
            return new HelpInfo(_info.Name, _info.Description, _info.Switches, _info.Examples, _info.Subcommands);
        }
    }
}