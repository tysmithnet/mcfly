// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 02-19-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="McFly.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommandLine;
using McFly.Core;
using McFly.Debugger;
using Newtonsoft.Json;
using RGiesecke.DllExport;
using StackFrame = McFly.Core.StackFrame;

namespace McFly
{
    /*
     * todo: 32 and 64 bit
     * todo: .NET support
     * todo: add dump information table (first frame, last frame, etc)
     * todo: help
     * todo: add simd and floating point register tables 
     * todo: add the rest of the registers
     * todo: add additional checks to sql
     */
    /// <summary>
    ///     Class McFlyExtension.
    /// </summary>
    public class McFlyExtension
    {
        /// <summary>
        ///     The control
        /// </summary>
        private static IDebugControl6 control;

        /// <summary>
        ///     The client
        /// </summary>
        private static IDebugClient5 client;

        /// <summary>
        ///     The registers
        /// </summary>
        private static IDebugRegisters2 registers;

        /// <summary>
        ///     The symbols
        /// </summary>
        private static IDebugSymbols5 symbols;

        /// <summary>
        ///     The last hr
        /// </summary>
        private static HRESULT LastHR;

        /// <summary>
        ///     The settings
        /// </summary>
        private static Settings settings;

        /// <summary>
        ///     The curr domain
        /// </summary>
        internal static AppDomain currDomain;

        /// <summary>
        ///     The showed intro
        /// </summary>
        private static bool showedIntro;

        /// <summary>
        ///     The p format
        /// </summary>
        private static readonly string pFormat = $":x{Marshal.SizeOf(IntPtr.Zero) * 2}";

        private static CompositionContainer compositionContainer;
        private static McFlyApp app;

        /// <summary>
        ///     Create debugger interface
        /// </summary>
        /// <param name="InterfaceId">The interface identifier.</param>
        /// <param name="Interface">The interface.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("dbgeng.dll")]
        internal static extern uint DebugCreate(ref Guid InterfaceId,
            [MarshalAs(UnmanagedType.IUnknown)] out object Interface);

        /// <summary>
        ///     Get the HRESULT code for the specified int
        /// </summary>
        /// <param name="Result">The result.</param>
        /// <returns>HRESULT.</returns>
        private static HRESULT ConvertIntToHResult(int Result)
        {
            // Convert to Uint
            var value = BitConverter.ToUInt32(BitConverter.GetBytes(Result), 0);

            return ConvertIntToHResult(value);
        }

        /// <summary>
        ///     Get the HRESULT code for the specified int
        /// </summary>
        /// <param name="Result">The result.</param>
        /// <returns>HRESULT.</returns>
        private static HRESULT ConvertIntToHResult(uint Result)
        {
            var hr = HRESULT.E_UNEXPECTED;
            try
            {
                hr = (HRESULT) Result;
            }
            catch
            {
            }
            return hr;
        }

        /// <summary>
        ///     Creates the i debug client.
        /// </summary>
        /// <returns>IDebugClient.</returns>
        private static IDebugClient CreateIDebugClient()
        {
            var guid = new Guid("27fe5639-8407-4f47-8364-ee118fb08ac8");
            object obj;
            var hr = DebugCreate(ref guid, out obj);
            if (hr < 0)
            {
                LastHR = ConvertIntToHResult(hr);
                WriteLine("SourceFix: Unable to acquire client interface");
                return null;
            }
            IDebugClient client = (IDebugClient5) obj;
            return client;
        }

        /// <summary>
        ///     Initializes the API.
        /// </summary>
        internal static void INIT_API()
        {
            try
            {
                settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(GetSettingsFilePath())); // todo: change
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
                try
                {
                    client = (IDebugClient5) CreateIDebugClient();
                    control = (IDebugControl6) client;
                    registers = (IDebugRegisters2) client;
                    symbols = (IDebugSymbols5) client;
                }
                catch
                {
                    LastHR = HRESULT.E_UNEXPECTED;
                }
        }

        /// <summary>
        ///     Debugs the extension initialize.
        /// </summary>
        /// <param name="Version">The version.</param>
        /// <param name="Flags">The flags.</param>
        /// <returns>HRESULT.</returns>
        [DllExport]
        public static HRESULT DebugExtensionInitialize(ref uint Version, ref uint Flags)
        {
            uint Major = 1;
            uint Minor = 0;
            Version = (Major << 16) + Minor;
            Flags = 0;

            ResolveEventHandler resolver = (o, e) =>
            {
                var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var name = new AssemblyName(e.Name);
                var path = Path.Combine(directory, $"{name.Name}.dll");
                return Assembly.LoadFrom(path);
            };

            // Set up the AppDomainSetup
            var setup = new AppDomainSetup();
            var assembly = Assembly.GetExecutingAssembly().Location;
            setup.ApplicationBase = assembly.Substring(0, assembly.LastIndexOf('\\') + 1);

            setup.ConfigurationFile = assembly + ".config";

            // Set up the Evidence
            var baseEvidence = AppDomain.CurrentDomain.Evidence;
            var evidence = new Evidence(baseEvidence);

            currDomain = AppDomain.CreateDomain("wbext", AppDomain.CurrentDomain.Evidence, setup);
            currDomain.UnhandledException += CurrDomain_UnhandledException;

            AppDomain.CurrentDomain.AssemblyResolve += resolver;
            currDomain.AssemblyResolve += resolver;

            return HRESULT.S_OK;
        }

        /// <summary>
        ///     Handles the UnhandledException event of the CurrDomain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs" /> instance containing the event data.</param>
        private static void CurrDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            INIT_API();
            WriteLine("SourceExt: An unhandled exception happened on the extension");
            WriteLine("  This error is related to the extension itself not the target.");
            WriteLine("  The information on the exception is below:\n");

            var ex = e.ExceptionObject as Exception;
            while (ex != null)
            {
                WriteLine("{0} - {1} at", ex.GetType().ToString(), ex.Message);
                WriteLine("{0}", ex.StackTrace);
                ex = ex.InnerException;
                if (ex != null)
                    WriteLine("\n----- Inner Exception -----------");
            }
        }

        /// <summary>
        ///     Debugs the extension notify.
        /// </summary>
        /// <param name="Notify">The notify.</param>
        /// <param name="Argument">The argument.</param>
        [DllExport]
        public static void DebugExtensionNotify(uint Notify, ulong Argument)
        {
            if (Notify == 2) 
                if (!showedIntro)
                {     
                    INIT_API();
                    var assembly = Assembly.GetExecutingAssembly();
                    var types = assembly.GetTypes().Where(x => typeof(IInjectable).IsAssignableFrom(x));
                    var typeCatalog = new TypeCatalog(types);
                    compositionContainer = new CompositionContainer(typeCatalog);
                    var dbgEng = new DbgEngProxy(control, client, registers);
                    string path = Path.Combine(Path.GetDirectoryName(assembly.Location), "mcfly.log");
                    var log = new DefaultLog(path);
                    compositionContainer.ComposeExportedValue<IDbgEngProxy>(dbgEng);
                    compositionContainer.ComposeExportedValue<ILog>(log);
                    

                    WriteLine("When this baby hits 88 miles per hour... you're gonna see some serious shit.");
                    showedIntro = true;
                }
        }

        [DllExport]
        public static HRESULT mf(IntPtr client, [MarshalAs(UnmanagedType.LPStr)] string args)
        {
            // il merge
            var argv = CommandLineToArgs(args);

            if (args.Length == 0)
            {
                WriteLine("Enter a command, run !mf help to get the help text");
                return HRESULT.S_OK;
            }

            var first = app.McFlyMethods.FirstOrDefault(x => x.Name == argv[0]);
            if (first == null)
            {
                WriteLine($"Unrecognized command: {argv[0]}, run !mf help to get the help text");
                return HRESULT.S_OK;
            }

            first.Process(argv.Skip(1).ToArray());

            return HRESULT.S_OK;
        }

        /// <summary>
        ///     Debugs the extension uninitialize.
        /// </summary>
        /// <returns>HRESULT.</returns>
        [DllExport]
        public static HRESULT DebugExtensionUninitialize()
        {
            if (currDomain != null)
                AppDomain.Unload(currDomain);

            return HRESULT.S_OK;
        }

        /// <summary>
        ///     Configurations the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>HRESULT.</returns>
        [DllExport]
        public static HRESULT config(IntPtr client, [MarshalAs(UnmanagedType.LPStr)] string args)
        {
            INIT_API();
            // il merge
            var argv = CommandLineToArgs(args);

            Parser.Default.ParseArguments<ConfigOptions>(argv)
                .WithParsed(opts => { Config(opts); });

            return HRESULT.S_OK;
        }

        /// <summary>
        ///     Gets the settings file path.
        /// </summary>
        /// <returns>System.String.</returns>
        private static string GetSettingsFilePath()
        {
            var settingsFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            settingsFile = Path.Combine(settingsFile, "mcfly.settings.json");
            return settingsFile;
        }

        /// <summary>
        ///     Configurations the specified opts.
        /// </summary>
        /// <param name="opts">The opts.</param>
        private static void Config(ConfigOptions opts)
        {
            var settingsFile = GetSettingsFilePath();
            if (opts.ShouldList)
            {
                WriteLine($"connection_string => {settings.ConnectionString}");
                WriteLine($"server_url => {settings.ServerUrl}");
                WriteLine($"launcher_path => {settings.LauncherPath}");
                WriteLine($"project => {settings.ProjectName}");
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
                    case "project":
                        settings.ProjectName = opts.Value;
                        break;
                }
                File.WriteAllText(settingsFile, JsonConvert.SerializeObject(settings, Formatting.Indented));
            }
        }

        /// <summary>
        ///     Uses the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>HRESULT.</returns>
        [DllExport]
        public static HRESULT use(IntPtr client, [MarshalAs(UnmanagedType.LPStr)] string args)
        {
            INIT_API();

            Use(args);

            return HRESULT.S_OK;
        }

        /// <summary>
        ///     Uses the specified project name.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
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
            settings.ProjectName = projectName;
        }

        /// <summary>
        ///     Starts the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>HRESULT.</returns>
        [DllExport]
        public static HRESULT start(IntPtr client, [MarshalAs(UnmanagedType.LPStr)] string args)
        {
            INIT_API();

            Start();

            return HRESULT.S_OK;
        }

        /// <summary>
        ///     Mfindexes the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>HRESULT.</returns>
        [DllExport]
        public static HRESULT mfindex(IntPtr client, [MarshalAs(UnmanagedType.LPStr)] string args)
        {
            INIT_API();

            var argv = CommandLineToArgs(args);

            Parser.Default.ParseArguments<IndexOptions>(argv)
                .WithParsed(async options => { await Index(options); }).WithNotParsed(errors =>
                {
                    WriteLine($"Error: Cannot parse index options:");
                    foreach (var error in errors)
                        WriteLine(error.ToString());
                });

            return HRESULT.S_OK;
        }

        /// <summary>
        ///     Indexes the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>Task.</returns>
        private static async Task Index(IndexOptions options)
        {
            using (var ew = new ExecuteWrapper(client))
            {
                Position endingPosition;
                if (options.End != null)
                {
                    endingPosition = Position.Parse(options.End);
                }
                else
                {
                    var end = ew.Execute("!tt 100");
                    var endMatch = Regex.Match(end, "Setting position: (?<pos>[A-F0-9]+:[A-F0-9]+)");
                    endingPosition = Position.Parse(endMatch.Groups["pos"].Value);
                }

                // clear breakpoints
                ew.Execute("bc *"); // todo: save existing break points and restore

                // set head at start
                ew.Execute(options.Start != null ? $"!tt {options.Start}" : "!tt 0");

                // set breakpoints
                if (options.BreakpointMasks != null)
                    foreach (var optionsBreakpointMask in options.BreakpointMasks)
                        ew.Execute($"bm {optionsBreakpointMask}");

                if (options.AccessBreakpoints != null)
                    foreach (var accessBreakpoint in options.AccessBreakpoints)
                    {
                        // todo: move
                        var match = Regex.Match(accessBreakpoint,
                            @"^\s*(?<access>[rw]{1,2})(?<length>[a-fA-F0-9]+):(?<address>[a-fA-F0-9]+)\s*$");
                        if (!match.Success)
                        {
                            WriteLine($"Error: invalid access breakpoint: {accessBreakpoint}");
                            continue;
                        }

                        foreach (var c in match.Groups["access"].Value)
                            ew.Execute($"ba {c}{match.Groups["length"].Value} {match.Groups["address"].Value}");
                    }

                var endReached = false;
                var is32Bit =
                    Regex.Match(ew.Execute("!peb"), @"PEB at (?<peb>[a-fA-F0-9]+)").Groups["peb"].Value.Length == 8;
                // loop through all the set break points and record relevant values
                DEBUG_STATUS status;
                var goStatuses = new[]
                {
                    DEBUG_STATUS.GO, DEBUG_STATUS.STEP_BRANCH, DEBUG_STATUS.STEP_INTO, DEBUG_STATUS.STEP_OVER,
                    DEBUG_STATUS.REVERSE_STEP_BRANCH, DEBUG_STATUS.REVERSE_STEP_INTO, DEBUG_STATUS.REVERSE_GO,
                    DEBUG_STATUS.REVERSE_STEP_OVER
                };
                while (true)
                {
                    // equivalent of g
                    control.SetExecutionStatus(DEBUG_STATUS.GO);
                    while (true)
                    {
                        control.GetExecutionStatus(out status);
                        if (goStatuses.Contains(status))
                        {
                            control.WaitForEvent(DEBUG_WAIT.DEFAULT,
                                uint.MaxValue); // todo: make reasonable and add counter.. shouldn't wait more than 10s
                            continue;
                        }

                        if (status == DEBUG_STATUS.BREAK)
                            break;
                    }
                    var records = GetPositions(ew).ToArray();
                    var breakRecord = records.Single(x => x.IsThreadWithBreak);
                    if (breakRecord.Position >= endingPosition)
                        break;

                    var frames = new List<Frame>();
                    foreach (var record in records)
                    {
                        RegisterSet registerSet;
                        // all threads currently at the same breakpoint position
                        if (record.Position == breakRecord.Position)
                        {
                            // here we collect the data
                            // get the register values
                            if (is32Bit)
                            {
                                uint eax;
                                registers.GetValue(9, out var debugValue);
                                eax = debugValue.I32;

                                uint ebx;
                                registers.GetValue(6, out debugValue);
                                ebx = debugValue.I32;

                                uint ecx;
                                registers.GetValue(8, out debugValue);
                                ecx = debugValue.I32;

                                uint edx;
                                registers.GetValue(7, out debugValue);
                                edx = debugValue.I32;

                                registerSet = new RegisterSet
                                {
                                    Rax = eax,
                                    Rbx = ebx,
                                    Rcx = ecx,
                                    Rdx = edx
                                };
                            }
                            else
                            {
                                ulong rax;
                                registers.GetValue(0, out var debugValue);
                                rax = debugValue.I64;

                                ulong rbx;
                                registers.GetValue(3, out debugValue);
                                rbx = debugValue.I64;

                                ulong rcx;
                                registers.GetValue(1, out debugValue);
                                rcx = debugValue.I64;

                                ulong rdx;
                                registers.GetValue(2, out debugValue);
                                rdx = debugValue.I64;

                                registers.GetValue(16, out debugValue);
                                var rip = debugValue.I64;
                                registerSet = new RegisterSet
                                {
                                    Rax = Convert.ToUInt64(rax),
                                    Rbx = Convert.ToUInt64(rbx),
                                    Rcx = Convert.ToUInt64(rcx),
                                    Rdx = Convert.ToUInt64(rdx)
                                };
                            }
                            var stackTrace = ew.Execute("k");

                            var stackFrames = new List<StackFrame>();
                            foreach (var m in Regex.Matches(stackTrace,
                                    @"(?<sp>[a-fA-F0-9`]+) (?<ret>[a-fA-F0-9`]+) (?<mod>.*)!(?<fun>.*)\+(?<off>[a-fA-F0-9x]+)?")
                                .Cast<Match>())
                            {
                                var stackPointer = Convert.ToUInt64(m.Groups["sp"].Value.Replace("`", ""), 16);
                                var returnAddress = Convert.ToUInt64(m.Groups["ret"].Value.Replace("`", ""), 16);
                                var module = m.Groups["mod"].Value;
                                var functionName = m.Groups["fun"].Value;
                                var offset = Convert.ToUInt32(m.Groups["off"].Value, 16);
                                var stackFrame = new StackFrame(stackPointer, returnAddress, module, functionName,
                                    offset);
                                stackFrames.Add(stackFrame);
                            }

                            var eipRegister = is32Bit ? "eip" : "rip";
                            var instructionText = ew.Execute($"u {eipRegister} L1");
                            var match = Regex.Match(instructionText,
                                @"(?<sp>[a-fA-F0-9`]+)\s+[a-fA-F0-9]+\s+(?<ins>\w+)\s+(?<extra>.+)?");

                            var frame = new Frame
                            {
                                Position = record.Position,
                                RegisterSet = registerSet,
                                ThreadId = record.ThreadId,
                                StackFrames = stackFrames,
                                OpcodeNmemonic = match.Groups["ins"].Success ? match.Groups["ins"].Value : null,
                                DisassemblyNote = match.Groups["extra"].Success ? match.Groups["extra"].Value : null
                            };
                            frames.Add(frame);
                        }
                    }
                    using (var serverClient = new ServerClient(new Uri(settings.ServerUrl)))
                    {
                        await serverClient.UpsertFrames(settings.ProjectName, frames);
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the positions.
        /// </summary>
        /// <param name="ew">The ew.</param>
        /// <returns>IEnumerable&lt;PositionsRecord&gt;.</returns>
        private static IEnumerable<PositionsRecord> GetPositions(ExecuteWrapper ew)
        {
            var positionsText = ew.Execute("!positions");

            var matches = Regex.Matches(positionsText,
                "(?<cur>>)?Thread ID=0x(?<tid>[A-F0-9]+) - Position: (?<maj>[A-F0-9]+):(?<min>[A-F0-9]+)");

            return matches.Cast<Match>().Select(x => new PositionsRecord
            {
                ThreadId = Convert.ToInt32(x.Groups["tid"].Value, 16),
                Position = new Position(Convert.ToInt32(x.Groups["maj"].Value, 16),
                    Convert.ToInt32(x.Groups["min"].Value, 16)),
                IsThreadWithBreak = x.Groups["cur"].Success
            });
        }

        /// <summary>
        ///     Starts this instance.
        /// </summary>
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
                var startInfo = new ProcessStartInfo
                {
                    FileName = settings.LauncherPath,
                    CreateNoWindow = false,
                    Environment = {{"ConnectionString", settings.ConnectionString}},
                    UseShellExecute = false
                };
                var p = Process.Start(startInfo);
            }
            catch (Exception e)
            {
                WriteLine($"Error starting server. Is your path correct? Message: {e.Message}");
                throw;
            }
        }

        /// <summary>
        ///     Initializes the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>HRESULT.</returns>
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

        /// <summary>
        ///     Initializes the specified opts.
        /// </summary>
        /// <param name="opts">The opts.</param>
        /// <returns>Task.</returns>
        private static async Task Init(InitOptions opts)
        {
            if (string.IsNullOrWhiteSpace(settings.ServerUrl))
            {
                WriteLine(
                    "You must set the server url in the settings: !config -k server_url -v http://localhost:5000");
                return;
            }

            if (string.IsNullOrWhiteSpace(opts.ProjectName))
            {
                WriteLine("You must specify a project name: !init -n my_new_project");
                return;
            }

            string starting = null;
            string ending = null;
            using (var ew = new ExecuteWrapper(client))
            {
                var start = ew.Execute("!tt 0");
                var startMatch = Regex.Match(start, "Setting position: (?<loc>[a-fA-F0-9]+:[a-fA-F0-9]+)");
                if (!startMatch.Success)
                {
                    WriteLine($"Error: Could not find the starting position");
                    return;
                }
                starting = startMatch.Groups["loc"].Value;

                var end = ew.Execute("!tt 100");
                var endMatch = Regex.Match(end, "Setting position: (?<loc>[a-fA-F0-9]+:[a-fA-F0-9]+)");

                if (!endMatch.Success)
                {
                    WriteLine($"Error: could not find the ending position");
                    return;
                }
                ending = endMatch.Groups["loc"].Value;
            }

            using (var httpClient = new HttpClient()) // todo: move to client
            {
                try
                {
                    var httpContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("projectName", opts.ProjectName),
                        new KeyValuePair<string, string>("startFrame", starting),
                        new KeyValuePair<string, string>("endFrame", ending)
                    });
                    var uri = new UriBuilder(settings.ServerUrl) {Path = "api/project"};
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

        /// <summary>
        ///     Commands the line to argv w.
        /// </summary>
        /// <param name="lpCmdLine">The lp command line.</param>
        /// <param name="pNumArgs">The p number arguments.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("shell32.dll", SetLastError = true)]
        private static extern IntPtr CommandLineToArgvW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine, out int pNumArgs);

        /// <summary>
        ///     Commands the line to arguments.
        /// </summary>
        /// <param name="commandLine">The command line.</param>
        /// <returns>System.String[].</returns>
        /// <exception cref="Win32Exception"></exception>
        public static string[] CommandLineToArgs(string commandLine)
        {
            int argc;
            var argv = CommandLineToArgvW(commandLine, out argc);
            if (argv == IntPtr.Zero)
                throw new Win32Exception();
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

        /// <summary>
        ///     Pointers the format.
        /// </summary>
        /// <param name="Message">The message.</param>
        /// <returns>System.String.</returns>
        public static string pointerFormat(string Message)
        {
            return Message.Replace(":%p", pFormat);
        }

        /// <summary>
        ///     Writes the specified message.
        /// </summary>
        /// <param name="Message">The message.</param>
        /// <param name="Params">The parameters.</param>
        public static void Write(string Message, params object[] Params)
        {
            if (Params == null)
                Out(Message);
            else
                Out(string.Format(pointerFormat(Message), Params));
        }

        /// <summary>
        ///     Writes the line.
        /// </summary>
        /// <param name="Message">The message.</param>
        /// <param name="Params">The parameters.</param>
        public static void WriteLine(string Message, params object[] Params)
        {
            if (Params == null)
                Out(Message);
            else
                Out(string.Format(pointerFormat(Message), Params));
            Out("\n");
        }

        /// <summary>
        ///     Writes the DML.
        /// </summary>
        /// <param name="Message">The message.</param>
        /// <param name="Params">The parameters.</param>
        public static void WriteDml(string Message, params object[] Params)
        {
            if (Params == null)
                OutDml(Message);
            else
                OutDml(string.Format(pointerFormat(Message), Params));
        }

        /// <summary>
        ///     Writes the DML line.
        /// </summary>
        /// <param name="Message">The message.</param>
        /// <param name="Params">The parameters.</param>
        public static void WriteDmlLine(string Message, params object[] Params)
        {
            if (Params == null)
                OutDml(Message);
            else
                OutDml(string.Format(pointerFormat(Message), Params));
            Out("\n");
        }

        /// <summary>
        ///     Outs the specified message.
        /// </summary>
        /// <param name="Message">The message.</param>
        public static void Out(string Message)
        {
            control.ControlledOutput(DEBUG_OUTCTL.ALL_CLIENTS, DEBUG_OUTPUT.NORMAL, Message);
        }

        /// <summary>
        ///     Outs the DML.
        /// </summary>
        /// <param name="Message">The message.</param>
        public static void OutDml(string Message)
        {
            control.ControlledOutput(DEBUG_OUTCTL.ALL_CLIENTS | DEBUG_OUTCTL.DML, DEBUG_OUTPUT.NORMAL, Message);
        }

        /// <summary>
        ///     Delegate Ioctl
        /// </summary>
        /// <param name="IoctlType">Type of the ioctl.</param>
        /// <param name="lpvData">The LPV data.</param>
        /// <param name="cbSizeOfContext">The cb size of context.</param>
        /// <returns>System.UInt32.</returns>
        internal delegate uint Ioctl(IG IoctlType, ref WDBGEXTS_CLR_DATA_INTERFACE lpvData, int cbSizeOfContext);
    }
}
