using GestaoDeClientes.Application.Interfaces;
using GestaoDeClientes.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestaoDeClientes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public LoginController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Authenticate(LoginModel login)
        {
            if(!(login.Username == "admin" && login.Password == "1234567"))
            {
                return BadRequest("Login Inválido");
            }

            var token = _tokenService.GenerateToken(login);


            return Ok(new { token });
        }
    }
}
