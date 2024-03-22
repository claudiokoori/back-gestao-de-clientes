using GestaoDeClientes.Application.Interfaces;
using GestaoDeClientes.Domain.Model;
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var result = await _client.GetByIdAsync(id);
            if (result is null)
            {
                return NotFound();
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
