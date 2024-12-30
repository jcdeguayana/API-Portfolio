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
        [HttpGet]
        public IActionResult GetAll()
        {
            ExperienceRepository experienceRepository = new ExperienceRepository();
            List<Experience> experiences = experienceRepository.Experiences;
            return Ok(experiences);
        }

        [HttpGet("{title}")]
        public IActionResult GetOne(string title)
        {
            ExperienceRepository experienceRepository = new ExperienceRepository();
            List<Experience> experiences = experienceRepository.Experiences;
            return Ok(experiences.Where(e=>e.Title.Contains(title)));
        }
    }
}
