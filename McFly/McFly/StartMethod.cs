using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McFly
{
    [Export(typeof(IMcFlyMethod))]
    public class StartMethod : IMcFlyMethod
    {
        [Import(typeof(Settings))]
        private Settings Settings { get; set; }

        [Import(typeof(ILog))]
        private ILog Log { get; set; }

        [Import(typeof(IDbgEngProxy))]
        private IDbgEngProxy DbgEngProxy { get; set; }

        public string Name { get; } = "start";
        
        public void Process(string[] args)
        {
            if (string.IsNullOrWhiteSpace(Settings.LauncherPath))
            {   
                Log.Error("Start called but no launcher path was set. Check the settings file.");
                return;
            }
            if (!File.Exists(Settings.LauncherPath))
            {
                Log.Error($"Start called but could not find file: {Settings.LauncherPath}");
                return;
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = Settings.LauncherPath,
                CreateNoWindow = false,
                Environment = { { "ConnectionString", Settings.ConnectionString } },
                UseShellExecute = false
            };
            var p = System.Diagnostics.Process.Start(startInfo);
        }
    }
}
