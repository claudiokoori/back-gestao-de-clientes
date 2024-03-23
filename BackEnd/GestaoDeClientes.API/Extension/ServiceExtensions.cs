using System;
using System.IO;
using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace GestaoDeClientes.API.Extension
{
    public static class ServiceExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "GestaoDeClientes.API",

                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Gestão de clientes",
                        },
                        Description = "Uma API para gestão de clientes é um sistema que fornece endpoints para realizar operações" +
                        " CRUD (Create, Read, Update, Delete) relacionadas aos clientes de uma empresa."
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Gestão de clientes API");
            });
        }
    }
}
