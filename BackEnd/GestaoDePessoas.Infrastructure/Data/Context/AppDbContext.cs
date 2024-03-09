using GestaoDeClientes.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeClientes.Infrastructure.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(k => k.Id);
            modelBuilder.Entity<Cliente>().Property(p => p.NomeCompleto).HasMaxLength(100);
            modelBuilder.Entity<Cliente>().HasIndex(p => p.CPF).IsUnique();
            modelBuilder.Entity<Cliente>().HasIndex(p => p.Telefone).IsUnique();
            modelBuilder.Entity<Cliente>().Property(p => p.Telefone).HasMaxLength(11);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSnakeCaseNamingConvention();
        }
    }
}
