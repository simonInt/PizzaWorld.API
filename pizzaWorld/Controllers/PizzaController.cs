using Microsoft.AspNetCore.Mvc;
using pizzaWorld.Models;
using pizzaWorld.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pizzaWorld.Controllers
{
    [ApiController]
    [Route("pizza")]
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Pizza>>> GetPizza()
        {
            return Ok(await _pizzaRepository.GetPizza());
        }

        [HttpGet("{pizzaId}", Name = "GetPizza")]
        public async Task<ActionResult<Pizza>> GetPizzaById(int pizzaId)
        {
            return Ok(await _pizzaRepository.GetPizzaById(pizzaId));
        }

        [HttpPost]
        public ActionResult CreatePizza([FromBody]Pizza pizza)
        {
            _pizzaRepository.CreatePizza(pizza);

            return CreatedAtRoute("GetPizza", new
            {
                PizzaId = pizza.PizzaId
            }, pizza);
        }

        [HttpPut]
        public ActionResult UpdatePizza([FromBody]Pizza pizza)
        {
            _pizzaRepository.UpdatePizza(pizza);
            return NoContent();
        }

        [HttpDelete("{pizzaId}")]
        public async Task<ActionResult> DeletePizza(int pizzaId)
        {
            Pizza pizza = await _pizzaRepository.GetPizzaById(pizzaId);

            if(pizza == null)
            {
                return NotFound("La pizza n'existe pas.");
            }

            await _pizzaRepository.DeletePizza(pizza);
            return NoContent();
        }
    }
}
