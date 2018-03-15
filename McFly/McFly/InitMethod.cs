using System.ComponentModel.Composition;
using CommandLine;

namespace McFly
{
    [Export(typeof(IMcFlyMethod))]
    [Export(typeof(InitMethod))]
    internal class InitMethod : IMcFlyMethod
    {
        [Import]
        protected internal IDbgEngProxy DbgEngProxy { get; set; }

        [Import]
        protected internal Settings Settings { get; set; }

        [Import]
        protected internal IServerClient ServerClient { get; set; }

        public string Name { get; } = "init";

        public void Process(string[] args)
        {
            Parser.Default.ParseArguments<InitOptions>(args)
                .WithParsed(options =>
                {
                    var start = DbgEngProxy.GetStartingPosition();
                    var end = DbgEngProxy.GetEndingPosition();
                    ServerClient.InitializeProject(options.ProjectName, start, end);
                });
        }
    }
}