using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace McFly
{
    [Export(typeof(IMcFlyMethod))]
    [Export(typeof(InitMethod))]
    internal class InitMethod : IMcFlyMethod
    {
        [Import]
        private IDbgEngProxy DbgEngProxy { get; set; }

        [Import]
        private Settings Settings { get; set; }

        public string Name { get; } = "init";
        public void Process(string[] args)
        {
            Parser.Default.ParseArguments<InitOptions>(args)
                .WithParsed<InitOptions>(options =>
                {
                    using (var client = new ServerClient(new Uri(Settings.ServerUrl)))
                    {
                        var start = DbgEngProxy.GetStartingPosition();
                        var end = DbgEngProxy.GetEndingPosition();
                        client.InitializeProject(options.ProjectName, start, end);
                    }
                });
        }
    }
}
