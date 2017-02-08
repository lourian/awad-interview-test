namespace Awad.Interview.Practices
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Autofac;
    using AutofacModule = Autofac.Module;

    /// <summary>
    /// Provides the base functionality for application module.
    /// </summary>
    public class AppModule : AutofacModule
    {
        #region Properties

        /// <summary>
        /// Gets all assembly concrette types except <see cref=""/>
        /// </summary>
        protected Type[] ThisAssemblyTypes
            => Assembly.GetAssembly(GetType())
                .GetTypes()
                .Where(t => !t.IsAbstract && !typeof(AppModule).IsAssignableFrom(t))
                .ToArray();

        #endregion

        #region Overriden methods

        /// <summary>
        /// Loads the application module.
        /// </summary>
        /// <param name="builder">An instance of the <see cref="ContainerBuilder"/> type.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterTypes(ThisAssemblyTypes)
                .AsSelf()
                .AsImplementedInterfaces();
        }

        #endregion
    }
}
