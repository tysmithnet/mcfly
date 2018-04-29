namespace McFly.Server.Data.SqlServer
{
    internal interface IDomainEntityConverter<TDomain, TEntity>
    {
        TDomain ToDomain(TEntity entity);
        TEntity ToEntity(TDomain domainObject);
    }
}