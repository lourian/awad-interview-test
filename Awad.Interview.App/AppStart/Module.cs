namespace Awad.Interview.App.AppStart
{
    using System;
    using Autofac;
    using Practices;
    using ProcessingModule = Processing.AppStart.Module;
    using SerializationModule = Serialization.AppStart.Module;

    /*
     * There is no real reason to use DI container here because we have no root objects and have to use
     * container as a service locator, but in real application I usually use such model of modularity.
     */
    internal class App : AppModule
    {
        private static readonly Lazy<IContainer> _container
            = new Lazy<IContainer>(CreateContainer, true);


        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterModule<ProcessingModule>()
                .RegisterModule<SerializationModule>();
        }


        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<App>();
            builder.RegisterType<Helper.Ip>().AsSelf();

            return builder.Build();
        }

        public static IContainer Container => _container.Value;
    }
}
