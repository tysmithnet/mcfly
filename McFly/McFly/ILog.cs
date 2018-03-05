using System;

namespace McFly
{
    public interface ILog : IInjectable
    {
        void Verbose(string message);
        void Debug(string message);
        void Info(string messasge);
        void Error(string message);
        void Error(Exception exception);
        void Fatal(string message);
        void Fatal(Exception exception);
    }
}