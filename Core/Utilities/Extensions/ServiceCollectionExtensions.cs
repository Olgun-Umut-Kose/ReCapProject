using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection,
            params ICoreModule[] modules)
        {
            foreach (ICoreModule coreModule in modules)
            {
                coreModule.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }

    }

}