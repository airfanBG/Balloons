using Ninject.Modules;
using Ninject.Extensions.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Balloons.Core;
using System.Reflection;
using Balloons.Interfaces;
using Balloons.Services;
using Balloons.Services.Commands;
using Ninject.Extensions.Factory;
using Ninject;

namespace Balloons.Configuration
{
    public class DependencyConfig : NinjectModule
    {
        public override void Load()
        {
            //1
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .Where(type => type != typeof(Engine))
                .BindDefaultInterface();
            });
            Bind<IEngine>().To<Engine>().InSingletonScope();

            Bind<CreateBalloonCommand>().ToSelf().InSingletonScope();
            Bind<CreateArrowCommand>().ToSelf().InSingletonScope();

           
            Bind<ICommandFactory>().ToFactory().InSingletonScope();
            Bind<IBalloonFactory>().ToFactory().InSingletonScope();
            Bind<IArrowFactory>().ToFactory().InSingletonScope();
           
          

            Bind(typeof(IAddArrow), typeof(IAddBalloon), typeof(IRemoveBalloon)).To<GamePlay>().InSingletonScope();

            ////2
            Bind<ICommand>().ToMethod(context =>
            {
                Type commandType = (Type)context.Parameters.Single().GetValue(context, null);
                return (ICommand)context.Kernel.Get(commandType);
            }).NamedLikeFactoryMethod((ICommandFactory commandFactory) => commandFactory.GetCommand(null));
        }
    }
}
