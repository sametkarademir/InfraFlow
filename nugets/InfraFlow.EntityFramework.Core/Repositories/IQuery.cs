namespace InfraFlow.EntityFramework.Core.Repositories;

public interface IQuery<T>
{
    IQueryable<T> Query();
}