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
        /*1- Propiedad privada y de solo lectura del tipo de la clase que quiero inyectar*/
        private readonly ExperienceRepository _experienceRepository;
        /*2- */
        public ExperienceController(ExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }
        [HttpGet] /*Solicitamos todo*/
        public IActionResult Get([FromQuery] bool IncludeDeleted = false)
        {
            /*ExperienceRepository experienceRepository = new ExperienceRepository();
            List<Experience> experiences = experienceRepository.Experiences;*/
            if (IncludeDeleted)
            {
                return Ok(_experienceRepository.Experiences);
            }
            else
            {
                return Ok(_experienceRepository.Experiences.Where(e=>e.State=="Active"));
            }
        }

        [HttpGet("{title}")] /*Solicitamos la experiencia ingresada por parametro*/
        public IActionResult GetOne(string title)
        {
            /*ExperienceRepository experienceRepository = new ExperienceRepository();
            List<Experience> experiences = experienceRepository.Experiences;*/
            return Ok(_experienceRepository.Experiences.Where(e=>e.Title.Contains(title)));
        }

        [HttpPost] /*Hacemos el recurso recibiendo por el body la nueva experiencia*/
        public IActionResult AddExperience([FromBody]ExperienceForCreationAndUpdateRequest RequestDto)
        {
            /*ExperienceRepository experienceRepository = new ExperienceRepository();
            List<Experience> experiences = experienceRepository.Experiences;*/
            Experience experience = new Experience()
            {
                Id = _experienceRepository.Experiences.Count()+1,
                Title = RequestDto.Title,
                Descripcion = RequestDto.Descripcion,
                ImagePath = RequestDto.ImagePath,
                Summary = "In processings"
            };
            _experienceRepository.Experiences.Add(experience);
            return Ok(_experienceRepository.Experiences);
        }

        [HttpPut("{Idexperience}")]
        public IActionResult UpdateExperience([FromRoute]int Idexperience,[FromBody] ExperienceForCreationAndUpdateRequest Request)
        {
            int ExperienceToModify = _experienceRepository.Experiences.FindIndex(e => e.Id == Idexperience);
            if (ExperienceToModify != 1)
            {
                Experience NewExperience = new Experience()
                {
                    Id = Idexperience,
                    Title = Request.Title,
                    Descripcion = Request.Descripcion,
                    ImagePath = Request.ImagePath,
                    Summary = _experienceRepository.Experiences[ExperienceToModify].Summary
                };
                _experienceRepository.Experiences[ExperienceToModify] = NewExperience;
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
            int ExperienceToDelete = _experienceRepository.Experiences.FindIndex(e => e.Id == IdExperience);
            if (ExperienceToDelete != 1)
            {
                Experience DeletedExperience = new Experience()
                {
                    Id = IdExperience,
                    Title = _experienceRepository.Experiences[ExperienceToDelete].Title,
                    Descripcion = _experienceRepository.Experiences[ExperienceToDelete].Descripcion,
                    ImagePath = _experienceRepository.Experiences[ExperienceToDelete].ImagePath,
                    Summary = _experienceRepository.Experiences[ExperienceToDelete].Summary,
                    State = "Deleted"
                };
                _experienceRepository.Experiences[ExperienceToDelete] = DeletedExperience;
                return NoContent();
            }
            return Ok();
        }
    }
}
