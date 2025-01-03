using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Entities;
using PortfolioAPI.Models;
using PortfolioAPI.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        [HttpGet] /*Solicitamos todo*/
        public IActionResult Get([FromQuery] bool IncludeDeleted = false)
        {
            /*ExperienceRepository experienceRepository = new ExperienceRepository();
            List<Experience> experiences = experienceRepository.Experiences;*/
            if (IncludeDeleted)
            {
                return Ok(ExperienceRepository.Experiences);
            }
            else
            {
                return Ok(ExperienceRepository.Experiences.Where(e=>e.State=="Active"));
            }
        }

        [HttpGet("{title}")] /*Solicitamos la experiencia ingresada por parametro*/
        public IActionResult GetOne(string title)
        {
            /*ExperienceRepository experienceRepository = new ExperienceRepository();
            List<Experience> experiences = experienceRepository.Experiences;*/
            return Ok(ExperienceRepository.Experiences.Where(e=>e.Title.Contains(title)));
        }

        [HttpPost] /*Hacemos el recurso recibiendo por el body la nueva experiencia*/
        public IActionResult AddExperience([FromBody]ExperienceForCreationAndUpdateRequest RequestDto)
        {
            /*ExperienceRepository experienceRepository = new ExperienceRepository();
            List<Experience> experiences = experienceRepository.Experiences;*/
            Experience experience = new Experience()
            {
                Id = ExperienceRepository.Experiences.Count()+1,
                Title = RequestDto.Title,
                Descripcion = RequestDto.Descripcion,
                ImagePath = RequestDto.ImagePath,
                Summary = "In processings"
            };
            ExperienceRepository.Experiences.Add(experience);
            return Ok(ExperienceRepository.Experiences);
        }

        [HttpPut("{Idexperience}")]
        public IActionResult UpdateExperience([FromRoute]int Idexperience,[FromBody] ExperienceForCreationAndUpdateRequest Request)
        {
            int ExperienceToModify = ExperienceRepository.Experiences.FindIndex(e => e.Id == Idexperience);
            if (ExperienceToModify != 1)
            {
                Experience NewExperience = new Experience()
                {
                    Id = Idexperience,
                    Title = Request.Title,
                    Descripcion = Request.Descripcion,
                    ImagePath = Request.ImagePath,
                    Summary = ExperienceRepository.Experiences[ExperienceToModify].Summary
                };
                ExperienceRepository.Experiences[ExperienceToModify] = NewExperience;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        /*[HttpDelete("{idExperience}")]

        public IActionResult DeleteExperience([FromRoute] int idExperience)
        {
            int ExperienceToDelete = ExperienceRepository.Experiences.FindIndex(e => e.Id == idExperience);
            ExperienceRepository.Experiences.RemoveAt(ExperienceToDelete);
            return Ok();
        }*/

        [HttpDelete("{IdExperience}")]

        public IActionResult DeleteLogic([FromRoute] int IdExperience)
        {
            int ExperienceToDelete = ExperienceRepository.Experiences.FindIndex(e => e.Id == IdExperience);
            if (ExperienceToDelete != 1)
            {
                Experience DeletedExperience = new Experience()
                {
                    Id = IdExperience,
                    Title = ExperienceRepository.Experiences[ExperienceToDelete].Title,
                    Descripcion = ExperienceRepository.Experiences[ExperienceToDelete].Descripcion,
                    ImagePath = ExperienceRepository.Experiences[ExperienceToDelete].ImagePath,
                    Summary = ExperienceRepository.Experiences[ExperienceToDelete].Summary,
                    State = "Deleted"
                };
                ExperienceRepository.Experiences[ExperienceToDelete] = DeletedExperience;
                return NoContent();
            }
            return Ok();
        }
    }
}
