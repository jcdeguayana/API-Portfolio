using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Entities;
using PortfolioAPI.Repositories;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        [HttpGet] /*Solicitamos todo*/
        public IActionResult GetAll()
        {
            ExperienceRepository experienceRepository = new ExperienceRepository();
            List<Experience> experiences = experienceRepository.Experiences;
            return Ok(experiences);
        }

        [HttpGet("{title}")] /*Solicitamos la experiencia ingresada por parametro*/
        public IActionResult GetOne(string title)
        {
            ExperienceRepository experienceRepository = new ExperienceRepository();
            List<Experience> experiences = experienceRepository.Experiences;
            return Ok(experiences.Where(e=>e.Title.Contains(title)));
        }

        [HttpPost] /*Hacemos el recurso recibiendo por el body la nueva experiencia*/
        public IActionResult AddExperience([FromBody]Experience experience)
        {
            ExperienceRepository experienceRepository = new ExperienceRepository();
            List<Experience> experiences = experienceRepository.Experiences;
            experiences.Add(experience);
            return Ok(experiences);
        }
    }
}
