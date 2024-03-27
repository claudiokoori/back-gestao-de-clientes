
using GestaoDeClientes.API.Extension;
using GestaoDeClientes.Application.Interfaces;
using GestaoDeClientes.Infrastructure.Data;
using GestaoDeClientes.Infrastructure.Extensions;
using GestaoDeClientes.Infrastructure.Services;
using GestaoDeClientes.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



namespace GestaoDeClientes.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSwagger();

            // Add services to the container.

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:4200")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });

            builder.Services.AddPersistenceInfrastructure(builder.Configuration);
            builder.Services.AddScoped<ICadastroCliente, CadastroCliente>();

            builder.Services.AddSingleton<ITokenService, TokenService>();

            builder.Services.AddJwtConfiguration(builder.Configuration);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
