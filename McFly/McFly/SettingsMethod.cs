using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace McFly
{
    [Export(typeof(IMcFlyMethod))]
    public class SettingsMethod : IMcFlyMethod
    {
        public string Name { get; } = "settings";

        public async Task Process(string[] args)
        {
            Parser.Default.ParseArguments<ReloadOptions>(args).WithParsed(r =>
            {
                McFlyExtension.PopulateSettings();
            });
        }
    }

    [Verb("reload", HelpText = "Reload the settings from the settings file")]
    public class ReloadOptions
    {
        
    }
}
