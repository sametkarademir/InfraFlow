using Autofac;
using InfraFlow.Infrastructure.Repositories.Concretes;
using InfraFlow.Infrastructure.Repositories.Interfaces;

namespace InfraFlow.Infrastructure;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TodoRepository>().As<ITodoRepository>().InstancePerLifetimeScope();
    }
}