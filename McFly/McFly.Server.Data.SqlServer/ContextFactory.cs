using System.ComponentModel.Composition;
using System.Data.SqlClient;

namespace McFly.Server.Data.SqlServer
{
    [Export(typeof(IContextFactory))]
    internal class ContextFactory : IContextFactory
    {
        [Import]
        protected internal Settings Settings { get; set; }

        public McFlyContext GetContext(string projectName)
        {
            var builder =
                new SqlConnectionStringBuilder(Settings.ConnectionString ?? "")
                {
                    InitialCatalog = $"mcfly_{projectName}"
                };
            return new McFlyContext(builder.ToString());
        }
    }
}