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

        [Import]
        protected internal ITimeTravelFacade TimeTravelFacade { get; set; }

        public string Name { get; } = "init";

        public void Process(string[] args)
        {
            Parser.Default.ParseArguments<InitOptions>(args)
                .WithParsed(options =>
                {
                    var start = TimeTravelFacade.GetStartingPosition();
                    var end = TimeTravelFacade.GetEndingPosition();
                    ServerClient.InitializeProject(options.ProjectName, start, end);
                });
        }
    }
}