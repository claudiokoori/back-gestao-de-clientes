using GestaoDeClientes.Domain.Model;

namespace GestaoDeClientes.Application.Interfaces
{
    public interface ICadastroCliente
    {
        Task<Cliente> GetByIdAsync(int id);
        Task<Cliente> CreateAsync(Cliente user);
        Task<Cliente> UpdateAsync(int id, Cliente user);
        Task<bool> DeleteAsync(int id);
    }
}
