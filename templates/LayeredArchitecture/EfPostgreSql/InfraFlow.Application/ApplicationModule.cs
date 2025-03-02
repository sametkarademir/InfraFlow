using Autofac;
using InfraFlow.Application.Services.Concretes;
using InfraFlow.Application.Services.Interfaces;

namespace InfraFlow.Application;

public class ApplicationModule : Module
{
     protected override void Load(ContainerBuilder builder)
    {
        //builder.RegisterType<AppSnapshotService>().As<IAppSnapshotService>().InstancePerLifetimeScope();
        //builder.RegisterType<AppSnapshotInitializerService>().As<IAppSnapshotInitializerService>().InstancePerLifetimeScope();
        builder.RegisterType<TodoAppService>().As<ITodoAppService>().InstancePerLifetimeScope();
    }
}