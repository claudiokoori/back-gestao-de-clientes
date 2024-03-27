using GestaoDeClientes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeClientes.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(LoginModel login);
    }
}
