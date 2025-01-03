
using PortfolioAPI.Entities;
namespace PortfolioAPI.Repositories
{
    public static class ExperienceRepository
    {
        /*Al ser la clase estática no se pierden en memoria los datos*/
        public static List<Experience> Experiences { get; set; } = new List<Experience>()
        {
            new Experience()
               {
                  Id = 1,
                  Title = "Programador Junior",
                  Descripcion = "Primera experiencia laboral",
                  ImagePath = "Ruta",
                  Summary = "por ahora no sé"
               },
               new Experience()
               {
                  Id = 2,
                  Title = "Programador Senior",
                  Descripcion = "Mucha experiencia laboral",
                  ImagePath = "Ruta",
                  Summary = "por ahora no sé"
               },
               new Experience()
               {
                  Id = 3,
                  Title = "Programador Backend C#",
                  Descripcion = "Primera experiencia laboral",
                  ImagePath = "Ruta",
                  Summary = "por ahora no sé"
               }
        };

        
        

        /*public ExperienceRepository()
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
        }*/



    }
}
