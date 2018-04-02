using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using McFly.Server.Contract;
using McFly.Server.Data.Search;

namespace McFly.Server.Search
{
    internal abstract class BaseSearchCriterionConverter : ISearchCriterionConverter
    {
        [DllImport("shell32.dll", SetLastError = true)]
        private static extern IntPtr CommandLineToArgvW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine, out int pNumArgs);

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

        /// <inheritdoc />
        public abstract bool CanConvert(SearchCriterionDto searchCriterionDto);

        /// <inheritdoc />
        public abstract ICriterion Convert(SearchCriterionDto searchCriterionDto);
    }
}