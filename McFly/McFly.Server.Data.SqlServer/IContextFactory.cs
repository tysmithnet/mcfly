namespace McFly.Server.Data.SqlServer
{
    internal interface IContextFactory
    {
        IMcFlyContext GetContext(string projectName);
    }
}