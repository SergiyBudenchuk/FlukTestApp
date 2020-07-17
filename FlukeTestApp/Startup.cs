using System;
using System.Text.Json.Serialization;
using AutoMapper;
using FlukeTestApp.DataProvider.Configurations;
using FlukeTestApp.ExceptionsFilter;
using FlukeTestApp.Services;
using FlukeTestApp.Services.Abstractions;
using FlukeTestApp.Services.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlukeTestApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest).AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.AddHttpClient();
            services.AddRazorPages();
            services.AddSwaggerGen(c => { c.UseInlineDefinitionsForEnums(); });
            services.AddAutoMapper(typeof(Startup));

            services.ConfigureServicesDependency();
            services.ConfigureDataProviderDependency();
            services.ConfigureMappers();

            services.AddControllers(options =>
                options.Filters.Add(new HttpResponseExceptionFilter()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseExceptionHandler("/error");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fluke API V1"); });
        }
    }
}