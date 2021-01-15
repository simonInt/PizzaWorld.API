using Microsoft.AspNetCore.Mvc;
using pizzaWorld.Models;
using pizzaWorld.Repositories;
using System.Collections.Generic;

namespace pizzaWorld.Controllers
{
    [ApiController]
    [Route("scooter")]
    public class ScooterController : Controller
    {
        private readonly IScooterRepository _scooterRepository;

        public ScooterController(IScooterRepository scooterRepository)
        {
            _scooterRepository = scooterRepository;
        }

        [HttpGet]
        public ActionResult<ICollection<Scooter>> GetScooter()
        {
            return Ok(_scooterRepository.GetScooter());
        }

        [HttpGet("{scooterId}", Name = "GetScooter")]
        public ActionResult<Scooter> GetScooterById(int scooterId)
        {
            return Ok(_scooterRepository.GetScooterById(scooterId));
        }

        [HttpPost]
        public ActionResult CreateScooter([FromBody]Scooter scooter)
        {
            _scooterRepository.CreateScooter(scooter);

            return CreatedAtRoute("GetScooter", new
            {
                ScooterId = scooter.ScooterId
            }, scooter);
        }

        [HttpPut]
        public ActionResult UpdateScooter([FromBody]Scooter scooter)
        {
            _scooterRepository.UpdateScooter(scooter);
            return NoContent();
        }

        [HttpDelete("{subjectId}")]
        public ActionResult DeleteScooter(int scooterId)
        {
            _scooterRepository.DeleteScooter(scooterId);
            return NoContent();
        }
    }
}
