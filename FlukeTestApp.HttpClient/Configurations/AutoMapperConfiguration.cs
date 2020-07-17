using AutoMapper;
using FlukeTestApp.DataProvider.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace FlukeTestApp.DataProvider.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureMappers(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EventMappingProfile());
                mc.AddProfile(new SourceMappingProfile());
                mc.AddProfile(new GeometrieMappingProfile());
                mc.AddProfile(new CategoryMapperProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}