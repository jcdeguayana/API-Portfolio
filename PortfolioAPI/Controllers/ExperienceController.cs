using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Entities;
using PortfolioAPI.Models;
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
            /*ExperienceRepository experienceRepository = new ExperienceRepository();
            List<Experience> experiences = experienceRepository.Experiences;*/
            return Ok(ExperienceRepository.Experiences);
        }

        [HttpGet("{title}")] /*Solicitamos la experiencia ingresada por parametro*/
        public IActionResult GetOne(string title)
        {
            /*ExperienceRepository experienceRepository = new ExperienceRepository();
            List<Experience> experiences = experienceRepository.Experiences;*/
            return Ok(ExperienceRepository.Experiences.Where(e=>e.Title.Contains(title)));
        }

        [HttpPost] /*Hacemos el recurso recibiendo por el body la nueva experiencia*/
        public IActionResult AddExperience([FromBody]ExperienceForCreationRequest RequestDto)
        {
            /*ExperienceRepository experienceRepository = new ExperienceRepository();
            List<Experience> experiences = experienceRepository.Experiences;*/
            Experience experience = new Experience()
            {
                Title = RequestDto.Title,
                Descripcion = RequestDto.Descripcion,
                ImagePath = RequestDto.ImagePath,
                Summary = "In processings"
            };
            ExperienceRepository.Experiences.Add(experience);
            return Ok(ExperienceRepository.Experiences);
        }
    }
}
