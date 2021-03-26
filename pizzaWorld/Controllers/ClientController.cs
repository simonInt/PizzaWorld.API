using Microsoft.AspNetCore.Mvc;
using pizzaWorld.Models;
using pizzaWorld.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pizzaWorld.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Client>>> GetClient()
        {
            return Ok(await _clientRepository.GetClient());
        }

        [HttpGet("{clientId}", Name = "GetClient")]
        public ActionResult<Client> GetClientById(int clientId)
        {
            return Ok(_clientRepository.GetClientById(clientId));
        }

        [HttpPost]
        public ActionResult CreateClient([FromBody]Client client)
        {
            _clientRepository.CreateClient(client);

            return CreatedAtRoute("GetClient", new
            {
                ClientId = client.ClientId
            }, client);
        }

        [HttpPut]
        public ActionResult UpdateClient([FromBody]Client client)
        {
            _clientRepository.UpdateClient(client);
            return NoContent();
        }

        [HttpDelete("{subjectId}")]
        public ActionResult DeleteClient(int clientId)
        {
            _clientRepository.DeleteClient(clientId);
            return NoContent();
        }
    }
}
