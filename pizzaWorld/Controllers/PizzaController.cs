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
        public ActionResult<Pizza> GetPizzaById(int pizzaId)
        {
            return Ok(_pizzaRepository.GetPizzaById(pizzaId));
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

        [HttpDelete("{subjectId}")]
        public ActionResult DeletePizza(int pizzaId)
        {
            _pizzaRepository.DeletePizza(pizzaId);
            return NoContent();
        }
    }
}
