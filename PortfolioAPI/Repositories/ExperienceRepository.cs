
using PortfolioAPI.Entities;
namespace PortfolioAPI.Repositories
{
    public class ExperienceRepository
    {
        public List<Experience> Experiences { get; set; }

        public ExperienceRepository()
        {
            Experiences = new List<Experience>()
            {
               new Experience()
               {
                  Title = "Programador Junior",
                  Descripcion = "Primera experiencia laboral",
                  ImagePath = "Ruta",
                  Summary = "por ahora no sé"
               },
               new Experience()
               {
                  Title = "Programador Senior",
                  Descripcion = "Mucha experiencia laboral",
                  ImagePath = "Ruta",
                  Summary = "por ahora no sé"
               },
               new Experience()
               {
                  Title = "Programador Backend C#",
                  Descripcion = "Primera experiencia laboral",
                  ImagePath = "Ruta",
                  Summary = "por ahora no sé"
               }

           };
        }

    }
}
