using System.ComponentModel.Composition;

namespace McFly.Server
{
    [Export]
    public sealed class Settings
    {
        internal Settings()
        {
        }

        public string ConnectionString { get; internal set; }
    }
}