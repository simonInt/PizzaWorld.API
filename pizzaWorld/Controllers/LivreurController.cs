using Microsoft.AspNetCore.Mvc;
using pizzaWorld.Models;
using pizzaWorld.Repositories;
using System.Collections.Generic;

namespace pizzaWorld.Controllers
{
    [ApiController]
    [Route("livreur")]
    public class LivreurController : Controller
    {
        private readonly ILivreurRepository _livreurRepository;

        public LivreurController(ILivreurRepository livreurRepository)
        {
            _livreurRepository = livreurRepository;
        }

        [HttpGet]
        public ActionResult<ICollection<Livreur>> GetLivreur()
        {
            return Ok(_livreurRepository.GetLivreur());
        }

        [HttpGet("{livreurId}", Name = "GetLivreur")]
        public ActionResult<Livreur> GetLivreurById(int livreurId)
        {
            return Ok(_livreurRepository.GetLivreurById(livreurId));
        }

        [HttpPost]
        public ActionResult CreateLivreur([FromBody]Livreur livreur)
        {
            _livreurRepository.CreateLivreur(livreur);

            return CreatedAtRoute("GetLivreur", new
            {
                LivreurId = livreur.LivreurId
            }, livreur);
        }

        [HttpPut]
        public ActionResult UpdateLivreur([FromBody]Livreur livreur)
        {
            _livreurRepository.UpdateLivreur(livreur);
            return NoContent();
        }

        [HttpDelete("{subjectId}")]
        public ActionResult DeleteLivreur(int livreurId)
        {
            _livreurRepository.DeleteLivreur(livreurId);
            return NoContent();
        }
    }
}
