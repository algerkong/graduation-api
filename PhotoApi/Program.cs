using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.TagHelpers.LayUI;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Logging;

namespace PhotoApi
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args)
        {

            return
                Host.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddWTMLogger();
                })
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.ConfigureServices(x =>
                    {
                        x.AddFrameworkService();
                        x.AddLayui();
                        x.AddSwaggerGen(c =>
                        {
                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                            var bearer = new OpenApiSecurityScheme()
                            {
                                Description = "JWT Bearer",
                                Name = "Authorization",
                                In = ParameterLocation.Header,
                                Type = SecuritySchemeType.ApiKey

                            };
                            c.AddSecurityDefinition("Bearer", bearer);
                            var sr = new OpenApiSecurityRequirement();
                            sr.Add(new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            }, new string[] { });
                            c.AddSecurityRequirement(sr);
                        });
                        x.AddSpaStaticFiles(configuration =>
                        {
                            configuration.RootPath = "ClientApp/build";
                        });
                    });
                     webBuilder.Configure(x =>
                     {
                        var env = x.ApplicationServices.GetService<IWebHostEnvironment>();
                        x.UseSwagger();
                        x.UseSwaggerUI(c =>
                        {
                            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                        });
                        if (env.IsDevelopment())
                        {
                            x.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                            {
                                HotModuleReplacement = false,
                                ConfigFile = "config/webpack.dev.js",
                                ProjectPath = System.IO.Path.Combine(env.ContentRootPath, "ClientApp/")

                            });
                        }
                        x.UseSpaStaticFiles();
                        x.UseFrameworkService();
                     });
                    }
                 );
        }
    }
}
