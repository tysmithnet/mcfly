namespace McFly.Server.Data.SqlServer
{
    internal interface IContextFactory
    {
        McFlyContext GetContext(string projectName);
    }
}