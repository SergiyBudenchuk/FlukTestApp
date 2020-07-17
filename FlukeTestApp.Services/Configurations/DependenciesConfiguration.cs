using FlukeTestApp.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace FlukeTestApp.Services.Configurations
{
    public static class DependenciesConfiguration
    {
        public static void ConfigureServicesDependency(this IServiceCollection services)
        {
            services.AddTransient<IEventService, EventService>();
        }
    }
}
