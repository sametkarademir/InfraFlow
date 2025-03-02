using InfraFlow.Core.Domain.Aggregates.Entities;

namespace InfraFlow.Core.EntityFramework.Repositories;

public interface IRepository<TEntity, TKey> :
    IQuery<TEntity>,
    IReadRepository<TEntity, TKey>,
    IWriteRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
{
    
}

public interface IRepository<TEntity> :
    IQuery<TEntity>,
    IReadRepository<TEntity>,
    IWriteRepository<TEntity>
    where TEntity : class, IEntity
{
    
}