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
                    builder => builder.WithOrigins("http://192.168.2.226:4200")//trabajo1
                    //builder => builder.WithOrigins("http://192.168.2.215:5004")//trabajoHostLocal
                    //builder => builder.WithOrigins("http://192.168.2.97:5004")//trabajoHostServer
                    //builder => builder.WithOrigins("http://192.168.1.123:4200")//casa
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }
    }
}
