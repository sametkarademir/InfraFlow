using Autofac;
using InfraFlow.Application.Services.Concretes;
using InfraFlow.Application.Services.Interfaces;

namespace InfraFlow.Application;

public class ApplicationModule : Module
{
     protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TodoAppService>().As<ITodoAppService>().InstancePerLifetimeScope();
    }
}