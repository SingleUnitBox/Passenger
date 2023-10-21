using Autofac;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Mappers;
using Passenger.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class CommandModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .AsSelf()
                .AsImplementedInterfaces();

            //var mapperConfiguration = AutomapperConfig.Initialize();

            //builder.RegisterInstance(mapperConfiguration)
            //    .SingleInstance();

            //builder.RegisterType<CommandDispatcher>()
            //    .As<ICommandDispatcher>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<UserService>()
            //    .As<IUserService>()
            //    .InstancePerLifetimeScope();
        }
    }
}
