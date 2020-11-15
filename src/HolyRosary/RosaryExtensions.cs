using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

using HolyRosary.Services;

namespace HolyRosary
{
    public static class RosaryExtensions 
    {
        public static IServiceCollection AddRosaryServices(this IServiceCollection services) 
        {
            services.AddSingleton<DateService>();
            services.AddSingleton<RosaryService>();
            services.AddSingleton<MysteryStorage>();

            return services;
        }

        public static IApplicationBuilder UseRosary(this IApplicationBuilder app, IWebHostEnvironment env) 
        {
            var storage = app.ApplicationServices.GetService<MysteryStorage>();
            if(storage != null) 
            {
                storage.LoadFiles(env);
            }

            return app;
        }
    }
}
