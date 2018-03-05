using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Reflection;

namespace McFly
{
    [Export(typeof(ILog))]
    public class DefaultLog : ILog, IDisposable
    {
        public void Dispose()
        {
            StreamWriter?.Dispose();
        }

        private StreamWriter StreamWriter { get; set; }

        public DefaultLog()
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            var path = Path.Combine(assemblyPath, "mcfly.log");
            var fs = File.Open(path, FileMode.Append);
            var bs = new BufferedStream(fs);
            StreamWriter = new StreamWriter(bs);
        }
            
        public void Verbose(string message)
        {
            StreamWriter.WriteLine($"[v] {DateTime.Now} {message}");
        }

        public void Debug(string message)
        {
            StreamWriter.WriteLine($"[d] {DateTime.Now} {message}");
        }

        public void Info(string message)
        {
            StreamWriter.WriteLine($"[i] {DateTime.Now} {message}");
        }

        public void Error(string message)
        {
            StreamWriter.WriteLine($"[e] {DateTime.Now} {message}");
        }

        public void Error(Exception exception)
        {
            StreamWriter.WriteLine($"[e] {DateTime.Now} {exception.Message}");
            do
            {
                StreamWriter.WriteLine(exception.StackTrace);
            } while ((exception = exception.InnerException) != null);

        }

        public void Fatal(string message)
        {
            StreamWriter.WriteLine($"[f] {DateTime.Now} {message}");
        }

        public void Fatal(Exception exception)
        {
            StreamWriter.WriteLine($"[f] {DateTime.Now} {exception.Message}");
            do
            {
                StreamWriter.WriteLine(exception.StackTrace);
            } while ((exception = exception.InnerException) != null);
        }
    }
}