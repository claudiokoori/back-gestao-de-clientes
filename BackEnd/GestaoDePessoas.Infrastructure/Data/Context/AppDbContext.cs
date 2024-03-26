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
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(k => k.Id);
            modelBuilder.Entity<Cliente>().Property(p => p.NomeCompleto).HasMaxLength(100);
            modelBuilder.Entity<Cliente>().HasIndex(p => p.CPF).IsUnique();
            modelBuilder.Entity<Cliente>().Property(p => p.CPF).HasMaxLength(11);
            modelBuilder.Entity<Cliente>().HasIndex(p => p.Telefone).IsUnique();
            modelBuilder.Entity<Cliente>().Property(p => p.Telefone).HasMaxLength(11);

            modelBuilder.Entity<Endereco>().HasKey(e => e.Id);
            modelBuilder.Entity<Endereco>().Ignore(i => i.Cliente);

            modelBuilder.Entity<Cliente>().HasOne<Endereco>(e => e.Endereco).WithOne(e => e.Cliente).HasForeignKey<Cliente>(c => c.EnderecoId).OnDelete(DeleteBehavior.Cascade); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSnakeCaseNamingConvention();
        }
    }
}
