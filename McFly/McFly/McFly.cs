using Microsoft.Diagnostics.Runtime.InteropLocal;
using RGiesecke.DllExport;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;

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
    public class WebBrowserExt
    {
        [DllImport("dbgeng.dll")]
        internal static extern uint DebugCreate(ref Guid InterfaceId, [MarshalAs(UnmanagedType.IUnknown)] out object Interface);

        private static IDebugControl6 control;
        private static IDebugClient5 client;
        private static HRESULT LastHR;

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
                return Assembly.LoadFrom(Path.ChangeExtension(
                    Path.Combine(directory, name.Name), ".dll"));
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
        public static HRESULT wb(IntPtr client, [MarshalAs(UnmanagedType.LPStr)] string args)
        {
            INIT_API();
            if (LastHR != HRESULT.S_OK)
                return LastHR;

            //var webClient = new WebClient();
            //var result = webClient.DownloadString(args);
            //var document = new HtmlDocument();
            //document.LoadHtml(result);
            //var writer = new StringWriter();
            //ConvertTo(args, document.DocumentNode, writer);
            //WriteDmlLine(writer.ToString());

            var argv = CommandLineToArgs(args);
            if (argv.Length < 2)
            {
                WriteLine($"Error: Invalid number of arguments");
                return HRESULT.E_INVALIDARG;
            }

            return HRESULT.S_OK;
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