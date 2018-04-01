namespace McFly.Server.Data.SqlServer
{
    internal interface IContextFactory : IInjectable
    {
        McFlyContext GetContext(string projectName);
    }
}