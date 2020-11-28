using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGM.Models
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://appweb.manacripex.com:5004", "http://192.168.2.97:5004", "http://192.168.2.221:5004", "http://192.168.2.211:4200")//trabajoHostServer
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }
    }
}
