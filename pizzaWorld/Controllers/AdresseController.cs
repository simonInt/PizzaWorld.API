using Microsoft.AspNetCore.Mvc;
using pizzaWorld.Models;
using pizzaWorld.Repositories;
using System.Collections.Generic;

namespace pizzaWorld.Controllers
{
    [ApiController]
    [Route("adresse")]
    public class AdresseController : Controller
    {
        private readonly IAdresseRepository _adresseRepository;

        public AdresseController(IAdresseRepository adresseRepository)
        {
            _adresseRepository = adresseRepository;
        }

        [HttpGet]
        public ActionResult<ICollection<Adresse>> GetAdresse()
        {
            return Ok(_adresseRepository.GetAdresse());
        }

        [HttpGet("{adresseId}", Name = "GetAdresse")]
        public ActionResult<Adresse> GetAdresseById(int adresseId)
        {
            return Ok(_adresseRepository.GetAdresseById(adresseId));
        }

        [HttpPost]
        public ActionResult CreateAdresse([FromBody]Adresse adresse)
        {
            _adresseRepository.CreateAdresse(adresse);

            return CreatedAtRoute("GetAdresse", new
            {
                AdresseId = adresse.AdresseId
            }, adresse);
        }

        [HttpPut]
        public ActionResult UpdateAdresse([FromBody]Adresse adresse)
        {
            _adresseRepository.UpdateAdresse(adresse);
            return NoContent();
        }

        [HttpDelete("{subjectId}")]
        public ActionResult DeleteAdresse(int adresseId)
        {
            _adresseRepository.DeleteAdresse(adresseId);
            return NoContent();
        }
    }
}
