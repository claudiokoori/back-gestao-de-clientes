using GestaoDeClientes.Application.Interfaces;
using GestaoDeClientes.Domain.Model;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestaoDeClientes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICadastroCliente _client;

        public ClienteController(ICadastroCliente client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<ActionResult<Cliente>> Get()
        {
            var result = await _client.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Endpoint responsável por consultar o cliente pelo id.
        /// </summary>
        /// <param name="id">Código de identificação</param>
        /// <returns>Returna o resultado da operação com objeto preenchido.</returns>
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var result = await _client.GetByIdAsync(id);
            if (result is null)
            {
                return NotFound(new
                {
                    Instance = $"api/Clientes/{id}",
                    status = 404,
                    error = "Recurso não encontrado",
                    message = "Ocorreu um erro ao tentar encontrar seu cliente.",
                    Method = "Get",
                });
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Post([FromBody] Cliente cliente)
        {
            var result = await _client.CreateAsync(cliente);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Cliente>> Put(int id, Cliente cliente)
        {
            var result = await _client.UpdateAsync(id, cliente);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await _client.DeleteAsync(id);
            return Ok(result);
        }
    }
}
