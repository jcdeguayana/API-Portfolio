using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Data.Repositories;
using PortfolioAPI.Entities;
using PortfolioAPI.Models;
using System.Reflection.Metadata.Ecma335;

namespace PortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /*[Authorize]*/
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
            if (IncludeDeleted)
                return Ok(_experienceRepository.GetAll());
            else
                return Ok(_experienceRepository.Get());
        }

        [HttpGet("{title}")] /*Solicitamos la experiencia ingresada por parametro*/
        public IActionResult GetOne(string title)
        {
            return Ok(_experienceRepository.GetOne(title));
        }

        [HttpPost] /*Hacemos el recurso recibiendo por el body la nueva experiencia*/
        public IActionResult AddExperience([FromBody]ExperienceForCreationAndUpdateRequest RequestDto)
        {
            Experience experience = new Experience()
            {
                Title = RequestDto.Title,
                Descripcion = RequestDto.Descripcion,
                ImgPath = RequestDto.ImagePath,
                Summary = "In processings"
            };
            return Ok(_experienceRepository.Add(experience));
        }


        [HttpPut("update/{Idexperience}")]
        public IActionResult UpdateExperience([FromRoute] int Idexperience, [FromBody] ExperienceForCreationAndUpdateRequest Request)
        {
            var ExperienceToModify = _experienceRepository.GetOne(Idexperience);
            if (ExperienceToModify != null)
            {
                // Actualizar las propiedades de la entidad existente
                ExperienceToModify.Title = Request.Title;
                ExperienceToModify.Descripcion = Request.Descripcion;
                ExperienceToModify.ImgPath = Request.ImagePath;

                // Actualizar el repositorio
                _experienceRepository.Modify(ExperienceToModify);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("delete/{idExperience}")]

        public IActionResult DeleteExperience([FromRoute] int idExperience)
        {
            _experienceRepository.Delete(idExperience);
            return Ok();
        }

        [HttpPut("logic-delete/{Id}")]

        public IActionResult LogicaElimination([FromRoute] int Id)
        {
            //int ExperienceToDelete = _experienceRepository.Experiences.FindIndex(e => e.Id == Idexperience);
            var ExperienceToDelete = _experienceRepository.GetOne(Id);
            if (ExperienceToDelete != null)
            {
                ExperienceToDelete.State = "Deleted";
                _experienceRepository.Modify(ExperienceToDelete);
                return NoContent();
            }
            return NotFound(); // Devuelve 404 si no se encuentra la experiencia
        }
    }
}
