namespace InfraFlow.Core.EntityFramework.Repositories;

public interface IQuery<T>
{
    IQueryable<T> Query();
}