using GestaoDeClientes.Application.Interfaces;
using GestaoDeClientes.Domain.Model;
using GestaoDeClientes.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeClientes.Infrastructure.Repositories
{
    public class CadastroCliente : ICadastroCliente
    {
        private readonly AppDbContext _context;

        public CadastroCliente(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            var result = await _context.Clientes.Include(c => c.Endereco).ToListAsync();
            
            return result;
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            var result = await _context.Clientes.Include(c => c.Endereco).FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<Cliente> CreateAsync(Cliente user)
        {
            _context.Clientes.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Cliente> UpdateAsync(int id, Cliente user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _context.Clientes.Include(c => c.Endereco).FirstOrDefaultAsync(u => u.Id == id);
            _context.Clientes.Remove(result);
            _context.Enderecos.Remove(result.Endereco);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
