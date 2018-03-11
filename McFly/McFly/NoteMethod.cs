using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace McFly
{
    internal class NoteMethod : IMcFlyMethod
    {
        public string Name { get; } = "note";

        [Import]
        public Settings Settings { get; set; }

        [Import]
        public IDbgEngProxy DbgEngProxy { get; set; }

        public void Process(string[] args)
        {
            Parser.Default.ParseArguments<AddNoteOptions>(args)
                .WithParsed<AddNoteOptions>(options =>
            {
                using (var client = new ServerClient(new Uri(Settings.ServerUrl)))
                {
                    // todo: make call
                }
            });
        }
    }

    [Verb("add", HelpText = "Add a note to the current position")]
    internal class AddNoteOptions
    {
        public string Content { get; set; }
    }
}
