using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace McFly
{
    [ExcludeFromCodeCoverage]
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
            });
        }
    }

    [Verb("add", HelpText = "Add a note to the current position")]
    internal class AddNoteOptions
    {
        public string Content { get; set; }
    }
}
