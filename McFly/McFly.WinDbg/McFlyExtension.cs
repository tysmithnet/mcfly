// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 02-19-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 04-22-2018
// ***********************************************************************
// <copyright file="McFly.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using McFly.WinDbg.Debugger;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RGiesecke.DllExport;

namespace McFly.WinDbg
{
    /*
     * todo: .NET support
     */
    /// <summary>
    ///     Class McFlyExtension.
    /// </summary>
    public class McFlyExtension
    {
        /// <summary>
        ///     The curr domain
        /// </summary>
        internal static AppDomain currDomain;

        /// <summary>
        ///     The application
        /// </summary>
        private static McFlyApp app;

        /// <summary>
        ///     The client
        /// </summary>
        private static IDebugClient5 client;

        /// <summary>
        ///     The composition container
        /// </summary>
        private static CompositionContainer compositionContainer;

        /// <summary>
        ///     The control
        /// </summary>
        private static IDebugControl6 control;

        /// <summary>
        ///     The debug data spaces
        /// </summary>
        private static IDebugDataSpaces debugDataSpaces;

        /// <summary>
        ///     The last hr
        /// </summary>
        private static HRESULT LastHR;

        /// <summary>
        ///     The log
        /// </summary>
        private static ILog log;

        /// <summary>
        ///     The p format
        /// </summary>
        private static readonly string pFormat = $":x{Marshal.SizeOf(IntPtr.Zero) * 2}";

        /// <summary>
        ///     The registers
        /// </summary>
        private static IDebugRegisters2 registers;

        /// <summary>
        ///     The settings
        /// </summary>
        private static Settings settings;

        /// <summary>
        ///     The showed intro
        /// </summary>
        private static bool showedIntro;

        /// <summary>
        ///     The symbols
        /// </summary>
        private static IDebugSymbols5 symbols;

        /// <summary>
        ///     The system objects
        /// </summary>
        private static IDebugSystemObjects systemObjects;

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

            currDomain = AppDomain.CreateDomain("mcfly", AppDomain.CurrentDomain.Evidence, setup);
            currDomain.UnhandledException += CurrDomain_UnhandledException;
            
            AppDomain.CurrentDomain.AssemblyResolve += resolver;
            currDomain.AssemblyResolve += resolver;

            return HRESULT.S_OK;
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
                    var assembly = Assembly.GetExecutingAssembly();
                    var path = Path.Combine(Path.GetDirectoryName(assembly.Location), "mcfly.log");
                    log = new DefaultLog(path);
                    InitApi(log);
                    var types = assembly.GetTypes().Where(x => typeof(IInjectable).IsAssignableFrom(x));
                    log.Debug($"Injectable types: {string.Join(", ", types.Select(x => x.FullName))}");
                    var typeCatalog = new TypeCatalog(types);
                    compositionContainer = new CompositionContainer(typeCatalog);
                    log.Debug("Creating debug engine proxy");
                    var dbgEng = new DebugEngineProxy(control, client, registers, systemObjects, debugDataSpaces);

                    log.Debug("Composing debug engine");
                    compositionContainer.ComposeExportedValue<IDebugEngineProxy>(dbgEng);
                    compositionContainer.ComposeExportedValue(log);
                    PopulateSettings();
                    app = compositionContainer.GetExportedValue<McFlyApp>();
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
            if (log != null)
                log.Dispose();
            if (currDomain != null)
                AppDomain.Unload(currDomain);

            return HRESULT.S_OK;
        }

        /// <summary>
        ///     Mfs the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>HRESULT.</returns>
        [DllExport]
        public static HRESULT mf(IntPtr client, [MarshalAs(UnmanagedType.LPStr)] string args)
        {
            // il merge
            var argv = CommandLineToArgs(args);

            if (argv.Length == 0)
            {
                WriteLine("Enter a command, run !mf help to get the help text");
                return HRESULT.S_OK;
            }

            var first = app.McFlyMethods.FirstOrDefault(x => x.HelpInfo.Name == argv[0]);
            if (first == null)
            {
                WriteLine($"Unrecognized command: {argv[0]}, run !mf help to get the help text");
                return HRESULT.S_OK;
            }

            try
            {
                first.Process(argv.Skip(1).ToArray());
            }
            catch (Exception e)
            {
                WriteLine("Unhandled exception");
                string message = GetExceptionMessage(e);
                WriteLine(message);
            }
            return HRESULT.S_OK;
        }

        private static string GetExceptionMessage(Exception e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{e.GetType().FullName} - {e.Message}");
            sb.AppendLine($"{e.StackTrace}");
            if (e.InnerException != null)
            {
                sb.AppendLine($"Inner exception: ");
                sb.AppendLine(GetExceptionMessage(e.InnerException));
            }
            return sb.ToString();
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
        ///     Pointers the format.
        /// </summary>
        /// <param name="Message">The message.</param>
        /// <returns>System.String.</returns>
        public static string pointerFormat(string Message)
        {
            return Message.Replace(":%p", pFormat);
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
            InitApi();

            Use(args);

            return HRESULT.S_OK;
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
        ///     Writes the line.
        /// </summary>
        /// <param name="Message">The message.</param>
        /// <param name="Params">The parameters.</param>
        public static void WriteLine(string Message, params object[] Params) // todo: allow for strategy pattern for different formats
        {
            if (Params == null)
                Out(Message);
            else
                Out(string.Format(pointerFormat(Message), Params));
            Out("\n");
        }

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
        ///     Gets the log path.
        /// </summary>
        /// <returns>System.String.</returns>
        internal static string GetLogPath()
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            assemblyPath = Path.GetDirectoryName(assemblyPath);
            return Path.Combine(assemblyPath, "mcfly.config");
        }

        /// <summary>
        ///     Initializes the API.
        /// </summary>
        /// <param name="log">The log.</param>
        internal static void InitApi(ILog log = null)
        {
            LastHR = HRESULT.S_OK;
            if (client != null) return;
            try
            {
                log?.Debug("Client did not exist. Creating a new client and associated interfaces.");
                client = (IDebugClient5) CreateIDebugClient();
                control = (IDebugControl6) client;
                registers = (IDebugRegisters2) client;
                symbols = (IDebugSymbols5) client;
                systemObjects = (IDebugSystemObjects) client;
                debugDataSpaces = (IDebugDataSpaces) client;
            }
            catch (Exception e)
            {
                log?.Fatal("Unable to create debug client. Are you missing DLLs?");
                log?.Fatal(e);
                LastHR = HRESULT.E_UNEXPECTED;
            }
        }

        /// <summary>
        ///     Populates the settings.
        /// </summary>
        internal static void PopulateSettings()
        {
            var settingsInstances = compositionContainer.GetExportedValues<ISettings>().ToArray();
            var filePath = GetLogPath();
            string json = null;
            try
            {
                json = File.ReadAllText(filePath);
            }
            catch (FileNotFoundException)
            {
                WriteLine("Settings file could not be fe found. Creating one now.");
                File.WriteAllText(filePath,
                    JsonConvert.SerializeObject(settingsInstances.AsEnumerable(), Formatting.Indented,
                        new SettingsJsonConverter()));
                return;
            }
            catch (Exception)
            {
                WriteLine("There was a problem opening the settings file. Is it locked?");
                return;
            }

            var rootObject = JObject.Parse(json);

            var numProcessed = 0;
            foreach (var prop in rootObject)
            {
                // {
                //     "McFly.IndexOptions": { ... } 
                //     ...
                // }
                var settingsInstance =
                    settingsInstances.SingleOrDefault(x => x.GetType().FullName == prop.Key);
                if (settingsInstance == null) continue;
                var settingsObject = prop.Value as JObject;
                JsonConvert.PopulateObject(settingsObject.ToString(), settingsInstance);
                numProcessed++;
            }

            if (settingsInstances.Count() != numProcessed)
                File.WriteAllText(filePath,
                    JsonConvert.SerializeObject(settingsInstances, Formatting.Indented, new SettingsJsonConverter()));
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
        ///     Handles the UnhandledException event of the CurrDomain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs" /> instance containing the event data.</param>
        private static void CurrDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            InitApi();
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
        ///     Delegate Ioctl
        /// </summary>
        /// <param name="IoctlType">Type of the ioctl.</param>
        /// <param name="lpvData">The LPV data.</param>
        /// <param name="cbSizeOfContext">The cb size of context.</param>
        /// <returns>System.UInt32.</returns>
        internal delegate uint Ioctl(IG IoctlType, ref WDBGEXTS_CLR_DATA_INTERFACE lpvData, int cbSizeOfContext);
    }
}