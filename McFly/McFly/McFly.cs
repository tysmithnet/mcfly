using RGiesecke.DllExport;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommandLine;
using McFly;
using McFly.Core;
using Microsoft.Diagnostics.Runtime.Interop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace McFly
{
    /*
     * todo: 32 and 64 bit
     * todo: .NET support
     * todo: add dump information table (first frame, last frame, etc)
     * todo: help
     * todo: add simd and floating point register tables 
     */
    public class McFlyExtension
    {
        [DllImport("dbgeng.dll")]
        internal static extern uint DebugCreate(ref Guid InterfaceId, [MarshalAs(UnmanagedType.IUnknown)] out object Interface);

        private static IDebugControl6 control;
        private static IDebugClient5 client;
        private static HRESULT LastHR;
        private static Settings settings;
        internal delegate uint Ioctl(IG IoctlType, ref WDBGEXTS_CLR_DATA_INTERFACE lpvData, int cbSizeOfContext);

        private static HRESULT Int2HResult(int Result)
        {
            // Convert to Uint
            uint value = BitConverter.ToUInt32(BitConverter.GetBytes(Result), 0);

            return Int2HResult(value);
        }

        private static HRESULT Int2HResult(uint Result)
        {
            HRESULT hr = HRESULT.E_UNEXPECTED;
            try
            {
                hr = (HRESULT)Result;

            }
            catch
            {

            }
            return hr;
        }
        private static IDebugClient CreateIDebugClient()
        {
            Guid guid = new Guid("27fe5639-8407-4f47-8364-ee118fb08ac8");
            object obj;
            var hr = DebugCreate(ref guid, out obj);
            if (hr < 0)
            {
                LastHR = Int2HResult(hr);
                WriteLine("SourceFix: Unable to acquire client interface");
                return null;
            }
            IDebugClient client = (IDebugClient5)obj;
            return client;
        }

        internal static void INIT_API()
        {
            try
            {
                settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(GetSettingsFilePath()));
            }
            catch (FileNotFoundException e)
            {
                settings = new Settings();
                File.WriteAllText(GetSettingsFilePath(), JsonConvert.SerializeObject(settings));
            }
            catch (Exception e)
            {
                WriteLine($"Error: Unable to get settings: {e}");
                throw;
            }

            LastHR = HRESULT.S_OK;
            if (client == null)
            {
                try
                {

                    client = (IDebugClient5)CreateIDebugClient();
                    control = (IDebugControl6)client;
                }
                catch
                {
                    LastHR = HRESULT.E_UNEXPECTED;
                }

            }
        }

        internal static AppDomain currDomain = null;

        [DllExport]
        public static HRESULT DebugExtensionInitialize(ref uint Version, ref uint Flags)
        {
            uint Major = 1;
            uint Minor = 0;
            Version = (Major << 16) + Minor;
            Flags = 0;

            ResolveEventHandler resolver = (o, e) =>
            {
                string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var name = new AssemblyName(e.Name);
                var path = Path.Combine(directory, $"{name.Name}.dll");
                return Assembly.LoadFrom(path);
            };
                                                              
            // Set up the AppDomainSetup
            AppDomainSetup setup = new AppDomainSetup();
            string assembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            setup.ApplicationBase = assembly.Substring(0, assembly.LastIndexOf('\\') + 1);

            setup.ConfigurationFile = assembly + ".config";

            // Set up the Evidence
            Evidence baseEvidence = AppDomain.CurrentDomain.Evidence;
            Evidence evidence = new Evidence(baseEvidence);

            currDomain = AppDomain.CreateDomain("wbext", AppDomain.CurrentDomain.Evidence, setup);
            currDomain.UnhandledException += CurrDomain_UnhandledException;

            AppDomain.CurrentDomain.AssemblyResolve += resolver;
            currDomain.AssemblyResolve += resolver;

            return HRESULT.S_OK;
        }

        private static void CurrDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            INIT_API();
            WriteLine("SourceExt: An unhandled exception happened on the extension");
            WriteLine("  This error is related to the extension itself not the target.");
            WriteLine("  The information on the exception is below:\n");

            Exception ex = e.ExceptionObject as Exception;
            while (ex != null)
            {
                WriteLine("{0} - {1} at", ex.GetType().ToString(), ex.Message);
                WriteLine("{0}", ex.StackTrace);
                ex = ex.InnerException;
                if (ex != null)
                {
                    WriteLine("\n----- Inner Exception -----------");
                }
            }
        }

        private static bool showedIntro = false;

        [DllExport]
        public static void DebugExtensionNotify(uint Notify, ulong Argument)
        {
            if (Notify == 2) // I can write now
            {
                if (!showedIntro) // Just once
                {
                    INIT_API();
                    WriteLine("When this baby hits 88 miles per hour... you're gonna see some serious shit.");
                    showedIntro = true;
                }
            }
        }

        [DllExport]
        public static HRESULT DebugExtensionUninitialize()
        {
            if (currDomain != null)
            {
                AppDomain.Unload(currDomain);
            }

            return HRESULT.S_OK;
        }

            
        [DllExport]
        public static HRESULT config(IntPtr client, [MarshalAs(UnmanagedType.LPStr)] string args)
        {
            INIT_API();
            // il merge
            var argv = CommandLineToArgs(args);

            Parser.Default.ParseArguments<ConfigOptions>(argv)
                .WithParsed<ConfigOptions>(opts =>
                {
                    Config(opts);
                });

            return HRESULT.S_OK;
        }

        private static string GetSettingsFilePath()
        {
            string settingsFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            settingsFile = Path.Combine(settingsFile, "mcfly.settings.json");
            return settingsFile;
        }

        private static void Config(ConfigOptions opts)
        {
            string settingsFile = GetSettingsFilePath();
            if (opts.ShouldList)
            {
                WriteLine($"connection_string => {settings.ConnectionString}");
                WriteLine($"server_url => {settings.ServerUrl}");
                WriteLine($"launcher_path => {settings.LauncherPath}");
                return;
            }
            if (opts.Key != null)
            {
                switch (opts.Key)
                {
                    case "connection_string":
                        settings.ConnectionString = opts.Value;
                        break;
                    case "server_url":
                        settings.ServerUrl = opts.Value;
                        break;
                    case "launcher_path":
                        settings.LauncherPath = opts.Value;
                        break;
                }
                File.WriteAllText(settingsFile, JsonConvert.SerializeObject(settings, Formatting.Indented));
            }
        }

        [DllExport]
        public static HRESULT use(IntPtr client, [MarshalAs(UnmanagedType.LPStr)] string args)
        {
            INIT_API();

            Use(args);

            return HRESULT.S_OK;
        }

        private static void Use(string projectName)
        {
            if (string.IsNullOrWhiteSpace(projectName))
            {
                WriteLine("Error: project name was not valid");
                return;
            }

            if (string.IsNullOrWhiteSpace(settings.ConnectionString))
            {
                WriteLine("Error: Connection string is not configured yet");
                return;
            }
            var sb = new SqlConnectionStringBuilder(settings.ConnectionString);
            sb.InitialCatalog = projectName;
            settings.ConnectionString = sb.ToString();
        }

        [DllExport]
        public static HRESULT start(IntPtr client, [MarshalAs(UnmanagedType.LPStr)] string args)
        {
            INIT_API();                       
                                                               
            Start();

            return HRESULT.S_OK;
        }


        [DllExport]
        public static HRESULT mfindex(IntPtr client, [MarshalAs(UnmanagedType.LPStr)] string args)
        {
            INIT_API();

            var argv = CommandLineToArgs(args);

            Parser.Default.ParseArguments<IndexOptions>(argv)
                .WithParsed(options =>
                {
                    Index(options);
                }).WithNotParsed(errors =>
                {
                    WriteLine($"Error: Cannot parse index options:");
                    foreach (var error in errors)
                    {
                        WriteLine(error.ToString());
                    }
                });

            return HRESULT.S_OK;
        }

        private static void Index(IndexOptions options)
        {
            Position? endingPosition = null;
            if(options.End != null)
                endingPosition = Position.Parse(options.End);

            SetupIndexBreakpoints(options);
            using (var ew = new ExecuteWrapper(client))
            {
                bool endReached = false;
                bool endOfTrace;
                // loop through all the set break points and record relevant values
                do
                {
                    var stop = ew.Execute("g");
                    var positionMatch = Regex.Match(stop, "Time Travel Position: (?<pos>[a-fA-F0-9]+:[a-fA-F0-9]+)");
                    endOfTrace = Regex.IsMatch(stop, "TTD: End of trace reached");
                    
                    if (!positionMatch.Success)
                    {
                        ; // todo: what to do here
                    }
                    var currentPosition = Position.Parse(positionMatch.Groups["pos"].Value); // todo: catch?
                    if (endingPosition.HasValue && currentPosition >= endingPosition.Value)
                    {
                        endReached = true;
                    }


                    // figure out which threads need to be recorded
                    var positionsRaw = ew.Execute("!positions");
                    var threadPositions = Regex.Matches(positionsRaw, "Thread ID=(?<tid>0x[a-fA-F0-9]+) - Position: (?<pos>[a-fA-F0-9]+:[a-fA-F0-9]+)")
                        .Cast<Match>().Select(x => (x.Groups["tid"].Value, x.Groups["pos"].Value));
                    int idx = 0;
                    foreach (var threadPositionPair in threadPositions)
                    {
                        var threadPosition = Position.Parse(threadPositionPair.Item2);
                        if (threadPosition == currentPosition)
                        {
                            // get the register values
                            var registerText = ew.Execute($"~~[{threadPositionPair.Item1}] rMF");

                        }
                        idx++;
                    }

                } while (!endReached && !endOfTrace); 
            }
        }

        private static void SetupIndexBreakpoints(IndexOptions options)
        {
            using (var ew = new ExecuteWrapper(client))
            {
                // clear breakpoints
                ew.Execute("bc *"); // todo: save existing break points and restore

                // set head at start
                ew.Execute(options.Start != null ? $"!tt {options.Start}" : "!tt 0");

                // set breakpoints
                if (options.BreakpointMasks != null)
                {
                    foreach (var optionsBreakpointMask in options.BreakpointMasks)
                    {
                        ew.Execute($"bm {optionsBreakpointMask}");
                    }
                }

                if (options.AccessBreakpoints != null)
                {
                    foreach (var accessBreakpoint in options.AccessBreakpoints)
                    {
                        // todo: move
                        var match = Regex.Match(accessBreakpoint,
                            @"^\s*(?<access>[rw][a-fA-F0-9]+):(?<address>[a-fA-F0-9]+)\s*$");
                        if (!match.Success)
                        {
                            WriteLine($"Error: invalid access breakpoint: {accessBreakpoint}");
                            continue;
                        }

                        ew.Execute($"ba {match.Groups["access"].Value} {match.Groups["address"].Value}");
                    }
                }

                if (options.BreakpointMasks != null)
                {
                    foreach (var optionsBreakpointMask in options.BreakpointMasks)
                    {
                        // todo: validate
                        ew.Execute($"bm {optionsBreakpointMask}");
                    }
                }
            }
        }

        private static void Start()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(settings.LauncherPath))
                {
                    WriteLine(
                        "You must set the launcher path in settings: !config -k launcher_path -v c:\\path\\to\\launch.bat");
                    return;
                }
                if (string.IsNullOrWhiteSpace(settings.ConnectionString))
                {
                    WriteLine(
                        "You must set the connection string in settings: !config -k connection_string -v \"Data Source=Whatever;Integrated Security=true\"");
                    return;
                }
                Process.Start($"{settings.LauncherPath}", $"--connectionstring \"{settings.ConnectionString}\"");
            }
            catch (Exception e)
            {
                WriteLine($"Error starting server. Is your path correct? Message: {e.Message}");
                throw;
            }
        }

        [DllExport]
        public static HRESULT init(IntPtr client, [MarshalAs(UnmanagedType.LPStr)] string args)
        {
            INIT_API();
            if (LastHR != HRESULT.S_OK)
                return LastHR;
                                               
            var argv = CommandLineToArgs(args);
            
            Parser.Default.ParseArguments<InitOptions>(argv)
                .WithParsed(async opts => await Init(opts));

            return HRESULT.S_OK;
        }

        private static async Task Init(InitOptions opts)
        {
            if (string.IsNullOrWhiteSpace(settings.ServerUrl))
            {
                WriteLine("You must set the server url in the settings: !config -k server_url -v http://localhost:5000");
                return;
            }

            if (string.IsNullOrWhiteSpace(opts.ProjectName))
            {
                WriteLine("You must specify a project name: !init -n my_new_project");
                return;
            }

            int startHi = 0;
            int startLo = 0;
            int endHi = 0;
            int endLo = 0;

            using (var ew = new ExecuteWrapper(client))
            {
                string start = ew.Execute("!tt 0");
                var startMatch = Regex.Match(start, "Setting position: (?<hi>[a-fA-F0-9]+):(?<lo>[a-fA-F0-9]+)");
                if (!startMatch.Success)
                {
                    WriteLine($"Error: Could not find the starting position");
                    return;
                }

                try
                {
                    startHi = Convert.ToInt32(startMatch.Groups["hi"].Value);
                    startLo = Convert.ToInt32(startMatch.Groups["lo"].Value);
                }
                catch (FormatException e)
                {
                    WriteLine($"Error: Could not convert found starting position values: {e.Message}");
                    WriteLine($"What is the value of !tt 0   ?");
                    return;
                }


                string end = ew.Execute("!tt 100");
                var endMatch = Regex.Match(start, "Setting position: (?<hi>[a-fA-F0-9]+):(?<lo>[a-fA-F0-9]+)");

                if (!endMatch.Success)
                {
                    WriteLine($"Error: could not find the ending position");
                    return;
                }
                try
                {
                    endHi = Convert.ToInt32(endMatch.Groups["hi"]);
                    endLo = Convert.ToInt32(endMatch.Groups["lo"]);
                }
                catch (FormatException e)
                {
                    WriteLine($"Error: Could not convert found ending position values: {e.Message}");
                    WriteLine($"What is the value of !tt 100   ?");
                    return;
                }   
            }

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var httpContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("projectName", opts.ProjectName),
                        new KeyValuePair<string, string>("start", opts.StartFrame),
                        new KeyValuePair<string, string>("end", opts.EndFrame),
                    });
                    var uri = new UriBuilder(settings.ServerUrl) { Path = "api/project" };
                    await httpClient.PostAsync(uri.Uri, httpContent);
                }
                catch (Exception e)
                {
                    WriteLine($"Error: Unable to create project: {e}");
                    WriteLine("Did you run !start   ?");
                    WriteLine("Can you access the swagger end point?");
                    return;
                }
            }
            Use(opts.ProjectName);
        }
        
        [DllImport("shell32.dll", SetLastError = true)]
        static extern IntPtr CommandLineToArgvW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine, out int pNumArgs);

        public static string[] CommandLineToArgs(string commandLine)
        {
            int argc;
            var argv = CommandLineToArgvW(commandLine, out argc);
            if (argv == IntPtr.Zero)
                throw new System.ComponentModel.Win32Exception();
            try
            {
                var args = new string[argc];
                for (var i = 0; i < args.Length; i++)
                {
                    var p = Marshal.ReadIntPtr(argv, i * IntPtr.Size);
                    args[i] = Marshal.PtrToStringUni(p);
                }

                return args;
            }
            finally
            {
                Marshal.FreeHGlobal(argv);
            }
        }
                        
        private static string pFormat = String.Format(":x{0}", Marshal.SizeOf(IntPtr.Zero) * 2);
        public static string pointerFormat(string Message)
        {
            return Message.Replace(":%p", pFormat);
        }

        public static void Write(string Message, params object[] Params)
        {
            if (Params == null)
                Out(Message);
            else
                Out(String.Format(pointerFormat(Message), Params));
        }

        public static void WriteLine(string Message, params object[] Params)
        {
            if (Params == null)
                Out(Message);
            else
                Out(String.Format(pointerFormat(Message), Params));
            Out("\n");
        }

        public static void WriteDml(string Message, params object[] Params)
        {
            if (Params == null)
                OutDml(Message);
            else
                OutDml(String.Format(pointerFormat(Message), Params));
        }

        public static void WriteDmlLine(string Message, params object[] Params)
        {
            if (Params == null)
                OutDml(Message);
            else
                OutDml(String.Format(pointerFormat(Message), Params));
            Out("\n");
        }
        public static void Out(string Message)
        {
            control.ControlledOutput(DEBUG_OUTCTL.ALL_CLIENTS, DEBUG_OUTPUT.NORMAL, Message);
        }

        public static void OutDml(string Message)
        {
            control.ControlledOutput(DEBUG_OUTCTL.ALL_CLIENTS | DEBUG_OUTCTL.DML, DEBUG_OUTPUT.NORMAL, Message);
        }
    }
}