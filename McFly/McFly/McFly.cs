using Microsoft.Diagnostics.Runtime.InteropLocal;
using RGiesecke.DllExport;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using McFly;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace wbext
{
    public enum HRESULT : uint
    {
        S_OK = 0,
        E_ABORT = 4,
        E_ACCESSDENIED = 0x80070005,
        E_FAIL = 0x80004005,
        E_HANDLE = 0x80070006,
        E_INVALIDARG = 0x80070057,
        E_NOINTERFACE = 0x80004002,
        E_NOTIMPL = 0x80004001,
        E_OUTOFMEMORY = 0x8007000E,
        E_POINTER = 0x80004003,
        E_UNEXPECTED = 0x8000FFFF

    }

    public class Settings
    {
        public string ConnectionString { get; set; }
        public string LauncherPath { get; set; }
        public string ServerUrl { get; set; }        
    }

    public class WebBrowserExt
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

            // Everything below is to enable the extension to be loaded from another
            //  folder that is not the same of the Debugger

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

        private static bool showedHello = false;

        [DllExport]
        public static void DebugExtensionNotify(uint Notify, ulong Argument)
        {
            if (Notify == 2) // I can write now
            {
                if (!showedHello) // Just once
                {
                    INIT_API();
                    WriteDmlLine("<b>wbext</b> 1.0");
                    WriteDmlLine("For help, type <link cmd=\"!help\">!help</link>");
                    showedHello = true;
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
        public static HRESULT help(IntPtr client, [MarshalAs(UnmanagedType.LPStr)] string Args)
        {
            INIT_API();

            if (String.IsNullOrWhiteSpace(Args))
            {
                WriteDmlLine("<link cmd=\"!help wb\">wb</link> - Displays a web page");
            }
            else
            {
                switch (Args.Trim().ToLower())
                {
                    case "wb":
                        WriteLine("Displays a web page at the specified address");
                        WriteLine("Syntax: wb <url>");
                        break;
                    default:
                        WriteLine("Command '{0}' not found", Args);
                        break;
                }
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

            using (var httpClient = new HttpClient())
            {                                   
                try
                {
                    var httpContent = new FormUrlEncodedContent(new []
                    {
                        new KeyValuePair<string, string>("projectName", opts.ProjectName), 
                    });
                    var uri = new UriBuilder(settings.ServerUrl) {Path = "api/project"};
                    await httpClient.PostAsync(uri.Uri, httpContent);
                }                                               
                catch (Exception e)
                {
                    WriteLine($"Error: Unable to create project: {e}");
                    throw;
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