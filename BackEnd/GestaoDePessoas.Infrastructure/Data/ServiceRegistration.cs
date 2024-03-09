using GestaoDeClientes.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoDeClientes.Infrastructure.Data
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<AppDbContext>(op => op.UseSqlServer(config.GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            return service;
        }

    }
}
