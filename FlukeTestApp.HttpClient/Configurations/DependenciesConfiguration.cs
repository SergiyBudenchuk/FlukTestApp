using FlukeTestApp.DataProvider.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace FlukeTestApp.DataProvider.Configurations
{
    public static class DependenciesConfiguration
    {
        public static void ConfigureDataProviderDependency(this IServiceCollection services)
        {
            services.AddTransient<IDataProvider, DataProvider>();
        }
    }
}