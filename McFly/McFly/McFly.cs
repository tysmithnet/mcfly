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
        private static readonly string pFormat = string.Format(":x{0}", Marshal.SizeOf(IntPtr.Zero) * 2);

        /// <summary>
        ///     Debugs the create.
        /// </summary>
        /// <param name="InterfaceId">The interface identifier.</param>
        /// <param name="Interface">The interface.</param>
        /// <returns>System.UInt32.</returns>
        [DllImport("dbgeng.dll")]
        internal static extern uint DebugCreate(ref Guid InterfaceId,
            [MarshalAs(UnmanagedType.IUnknown)] out object Interface);

        /// <summary>
        ///     Int2s the h result.
        /// </summary>
        /// <param name="Result">The result.</param>
        /// <returns>HRESULT.</returns>
        private static HRESULT Int2HResult(int Result)
        {
            // Convert to Uint
            var value = BitConverter.ToUInt32(BitConverter.GetBytes(Result), 0);

            return Int2HResult(value);
        }

        /// <summary>
        ///     Int2s the h result.
        /// </summary>
        /// <param name="Result">The result.</param>
        /// <returns>HRESULT.</returns>
        private static HRESULT Int2HResult(uint Result)
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
                LastHR = Int2HResult(hr);
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
            if (Notify == 2) // I can write now
                if (!showedIntro) // Just once
                {
                    INIT_API();
                    WriteLine("When this baby hits 88 miles per hour... you're gonna see some serious shit.");
                    showedIntro = true;
                }
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
                                    Rax = Convert.ToInt64(rax),
                                    Rbx = Convert.ToInt64(rbx),
                                    Rcx = Convert.ToInt64(rcx),
                                    Rdx = Convert.ToInt64(rdx)
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

    /// <summary>
    ///     One line of !positions
    /// </summary>
    public class PositionsRecord
    {
        /// <summary>
        ///     Gets or sets the thread identifier.
        /// </summary>
        /// <value>The thread identifier.</value>
        public int ThreadId { get; set; }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public Position Position { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is thread with break.
        /// </summary>
        /// <value><c>true</c> if this instance is thread with break; otherwise, <c>false</c>.</value>
        public bool IsThreadWithBreak { get; set; }
    }
}

/*
64 bit
0:rax
1:rcx
2:rdx
3:rbx
4:rsp
5:rbp
6:rsi
7:rdi
8:r8
9:r9
10:r10
11:r11
12:r12
13:r13
14:r14
15:r15
16:rip
17:efl
18:cs
19:ds
20:es
21:fs
22:gs
23:ss
24:dr0
25:dr1
26:dr2
27:dr3
28:dr6
29:dr7
30:fpcw
31:fpsw
32:fptw
33:st0
34:st1
35:st2
36:st3
37:st4
38:st5
39:st6
40:st7
41:mm0
42:mm1
43:mm2
44:mm3
45:mm4
46:mm5
47:mm6
48:mm7
49:mxcsr
50:xmm0
51:xmm1
52:xmm2
53:xmm3
54:xmm4
55:xmm5
56:xmm6
57:xmm7
58:xmm8
59:xmm9
60:xmm10
61:xmm11
62:xmm12
63:xmm13
64:xmm14
65:xmm15
66:xmm0/0
67:xmm0/1
68:xmm0/2
69:xmm0/3
70:xmm1/0
71:xmm1/1
72:xmm1/2
73:xmm1/3
74:xmm2/0
75:xmm2/1
76:xmm2/2
77:xmm2/3
78:xmm3/0
79:xmm3/1
80:xmm3/2
81:xmm3/3
82:xmm4/0
83:xmm4/1
84:xmm4/2
85:xmm4/3
86:xmm5/0
87:xmm5/1
88:xmm5/2
89:xmm5/3
90:xmm6/0
91:xmm6/1
92:xmm6/2
93:xmm6/3
94:xmm7/0
95:xmm7/1
96:xmm7/2
97:xmm7/3
98:xmm8/0
99:xmm8/1
100:xmm8/2
101:xmm8/3
102:xmm9/0
103:xmm9/1
104:xmm9/2
105:xmm9/3
106:xmm10/0
107:xmm10/1
108:xmm10/2
109:xmm10/3
110:xmm11/0
111:xmm11/1
112:xmm11/2
113:xmm11/3
114:xmm12/0
115:xmm12/1
116:xmm12/2
117:xmm12/3
118:xmm13/0
119:xmm13/1
120:xmm13/2
121:xmm13/3
122:xmm14/0
123:xmm14/1
124:xmm14/2
125:xmm14/3
126:xmm15/0
127:xmm15/1
128:xmm15/2
129:xmm15/3
130:xmm0l
131:xmm1l
132:xmm2l
133:xmm3l
134:xmm4l
135:xmm5l
136:xmm6l
137:xmm7l
138:xmm8l
139:xmm9l
140:xmm10l
141:xmm11l
142:xmm12l
143:xmm13l
144:xmm14l
145:xmm15l
146:xmm0h
147:xmm1h
148:xmm2h
149:xmm3h
150:xmm4h
151:xmm5h
152:xmm6h
153:xmm7h
154:xmm8h
155:xmm9h
156:xmm10h
157:xmm11h
158:xmm12h
159:xmm13h
160:xmm14h
161:xmm15h
162:ymm0
163:ymm1
164:ymm2
165:ymm3
166:ymm4
167:ymm5
168:ymm6
169:ymm7
170:ymm8
171:ymm9
172:ymm10
173:ymm11
174:ymm12
175:ymm13
176:ymm14
177:ymm15
178:ymm0/0
179:ymm0/1
180:ymm0/2
181:ymm0/3
182:ymm1/0
183:ymm1/1
184:ymm1/2
185:ymm1/3
186:ymm2/0
187:ymm2/1
188:ymm2/2
189:ymm2/3
190:ymm3/0
191:ymm3/1
192:ymm3/2
193:ymm3/3
194:ymm4/0
195:ymm4/1
196:ymm4/2
197:ymm4/3
198:ymm5/0
199:ymm5/1
200:ymm5/2
201:ymm5/3
202:ymm6/0
203:ymm6/1
204:ymm6/2
205:ymm6/3
206:ymm7/0
207:ymm7/1
208:ymm7/2
209:ymm7/3
210:ymm8/0
211:ymm8/1
212:ymm8/2
213:ymm8/3
214:ymm9/0
215:ymm9/1
216:ymm9/2
217:ymm9/3
218:ymm10/0
219:ymm10/1
220:ymm10/2
221:ymm10/3
222:ymm11/0
223:ymm11/1
224:ymm11/2
225:ymm11/3
226:ymm12/0
227:ymm12/1
228:ymm12/2
229:ymm12/3
230:ymm13/0
231:ymm13/1
232:ymm13/2
233:ymm13/3
234:ymm14/0
235:ymm14/1
236:ymm14/2
237:ymm14/3
238:ymm15/0
239:ymm15/1
240:ymm15/2
241:ymm15/3
242:ymm0l
243:ymm1l
244:ymm2l
245:ymm3l
246:ymm4l
247:ymm5l
248:ymm6l
249:ymm7l
250:ymm8l
251:ymm9l
252:ymm10l
253:ymm11l
254:ymm12l
255:ymm13l
256:ymm14l
257:ymm15l
258:ymm0h
259:ymm1h
260:ymm2h
261:ymm3h
262:ymm4h
263:ymm5h
264:ymm6h
265:ymm7h
266:ymm8h
267:ymm9h
268:ymm10h
269:ymm11h
270:ymm12h
271:ymm13h
272:ymm14h
273:ymm15h
274:exfrom
275:exto
276:brfrom
277:brto
278:eax
279:ecx
280:edx
281:ebx
282:esp
283:ebp
284:esi
285:edi
286:r8d
287:r9d
288:r10d
289:r11d
290:r12d
291:r13d
292:r14d
293:r15d
294:eip
295:ax
296:cx
297:dx
298:bx
299:sp
300:bp
301:si
302:di
303:r8w
304:r9w
305:r10w
306:r11w
307:r12w
308:r13w
309:r14w
310:r15w
311:ip
312:fl
313:al
314:cl
315:dl
316:bl
317:spl
318:bpl
319:sil
320:dil
321:r8b
322:r9b
323:r10b
324:r11b
325:r12b
326:r13b
327:r14b
328:r15b
329:ah
330:ch
331:dh
332:bh
333:iopl
334:of
335:df
336:if
337:tf
338:sf
339:zf
340:af
341:pf
342:cf
343:vip
344:vif

x86
0:gs
1:fs
2:es
3:ds
4:edi
5:esi
6:ebx
7:edx
8:ecx
9:eax
10:ebp
11:eip
12:cs
13:efl
14:esp
15:ss
16:dr0
17:dr1
18:dr2
19:dr3
20:dr6
21:dr7
22:di
23:si
24:bx
25:dx
26:cx
27:ax
28:bp
29:ip
30:fl
31:sp
32:bl
33:dl
34:cl
35:al
36:bh
37:dh
38:ch
39:ah
40:fpcw
41:fpsw
42:fptw
43:fopcode
44:fpip
45:fpipsel
46:fpdp
47:fpdpsel
48:st0
49:st1
50:st2
51:st3
52:st4
53:st5
54:st6
55:st7
56:mm0
57:mm1
58:mm2
59:mm3
60:mm4
61:mm5
62:mm6
63:mm7
64:mxcsr
65:xmm0
66:xmm1
67:xmm2
68:xmm3
69:xmm4
70:xmm5
71:xmm6
72:xmm7
73:iopl
74:of
75:df
76:if
77:tf
78:sf
79:zf
80:af
81:pf
82:cf
83:vip
84:vif
85:xmm0l
86:xmm1l
87:xmm2l
88:xmm3l
89:xmm4l
90:xmm5l
91:xmm6l
92:xmm7l
93:xmm0h
94:xmm1h
95:xmm2h
96:xmm3h
97:xmm4h
98:xmm5h
99:xmm6h
100:xmm7h
101:xmm0/0
102:xmm0/1
103:xmm0/2
104:xmm0/3
105:xmm1/0
106:xmm1/1
107:xmm1/2
108:xmm1/3
109:xmm2/0
110:xmm2/1
111:xmm2/2
112:xmm2/3
113:xmm3/0
114:xmm3/1
115:xmm3/2
116:xmm3/3
117:xmm4/0
118:xmm4/1
119:xmm4/2
120:xmm4/3
121:xmm5/0
122:xmm5/1
123:xmm5/2
124:xmm5/3
125:xmm6/0
126:xmm6/1
127:xmm6/2
128:xmm6/3
129:xmm7/0
130:xmm7/1
131:xmm7/2
132:xmm7/3
133:ymm0
134:ymm1
135:ymm2
136:ymm3
137:ymm4
138:ymm5
139:ymm6
140:ymm7
141:ymm0l
142:ymm1l
143:ymm2l
144:ymm3l
145:ymm4l
146:ymm5l
147:ymm6l
148:ymm7l
149:ymm0h
150:ymm1h
151:ymm2h
152:ymm3h
153:ymm4h
154:ymm5h
155:ymm6h
156:ymm7h
157:ymm0/0
158:ymm0/1
159:ymm0/2
160:ymm0/3
161:ymm1/0
162:ymm1/1
163:ymm1/2
164:ymm1/3
165:ymm2/0
166:ymm2/1
167:ymm2/2
168:ymm2/3
169:ymm3/0
170:ymm3/1
171:ymm3/2
172:ymm3/3
173:ymm4/0
174:ymm4/1
175:ymm4/2
176:ymm4/3
177:ymm5/0
178:ymm5/1
179:ymm5/2
180:ymm5/3
181:ymm6/0
182:ymm6/1
183:ymm6/2
184:ymm6/3
185:ymm7/0
186:ymm7/1
187:ymm7/2
188:ymm7/3
*/