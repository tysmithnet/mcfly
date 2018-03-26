using System.Collections.Generic;
using System.Linq;

namespace McFly
{
    public class HelpInfoBuilder
    {
        private HelpInfo _info;

        public HelpInfoBuilder()
        {
            _info = new HelpInfo();
            _info.Examples = new Dictionary<string, string>();
            _info.Subcommands = new HelpInfo[0];
            _info.Switches = new Dictionary<string, string>();
        }

        public HelpInfoBuilder SetName(string name)
        {
            _info.Name = name;
            return this;
        }

        public HelpInfoBuilder SetDescription(string description)
        {
            _info.Description = description;
            return this;
        }

        public HelpInfoBuilder AddSwitch(string @switch, string description)
        {
            if (!_info.Switches.ContainsKey(@switch))
                _info.Switches.Add(@switch, description);
            else
                _info.Switches[@switch] = description;
            return this;
        }

        public HelpInfoBuilder AddSubcommand(HelpInfo subcommand)
        {
            var list = _info.Subcommands.ToList();
            var existing = list.FirstOrDefault(x => x.Name == subcommand.Name);
            if (existing != null)
            {
                list.Remove(existing);
            }
            list.Add(subcommand);
            _info.Subcommands = list.OrderBy(x => x.Name).ToArray();
            return this;
        }

        public HelpInfoBuilder AddExample(string example, string description)
        {
            if (!_info.Examples.ContainsKey(example))
                _info.Examples.Add(example, description);
            else
                _info.Examples[example] = description;
            return this;
        }

        public HelpInfo Build()
        {
            return new HelpInfo(_info.Name, _info.Description, _info.Switches, _info.Examples, _info.Subcommands);
        }
    }
}