using Challeng_BP4.Data.repositorios;
using Challeng_BP4.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challeng_BP4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            return Ok(await _clientRepository.GetAllClients());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            return Ok(await _clientRepository.GetClient(id));
        }

        [HttpPost]

        public async Task<IActionResult> CreateClient([FromBody] Client client)
        {
            if (client == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _clientRepository.CreateClient(client);

            return Created("created", created);
            
        }

        [HttpPut]

        public async Task<IActionResult> UpdateClient([FromBody] Client client)
        {
            if (client == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _clientRepository.UpdateClient(client);

            return NoContent();

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientRepository.DeleteClient(new Client { ID = id });

            return NoContent();
        }

    }
}
