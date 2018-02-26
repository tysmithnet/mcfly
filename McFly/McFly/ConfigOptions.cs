using CommandLine;

namespace McFly
{
    public class ConfigOptions
    {
        [Option('l', "list", HelpText = "List the current settings and their values", SetName = "list")]
        public bool ShouldList { get; set; }

        [Option('k', "key", HelpText = "Key for the config setting", SetName = "set")]
        public string Key { get; set; }

        [Option('v', "value", HelpText = "Value for the config setting", SetName = "set")]
        public string Value { get; set; }
    }
}