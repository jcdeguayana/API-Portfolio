
using PortfolioAPI.Data;
using PortfolioAPI.Entities;

namespace PortfolioAPI.Data.Repositories
{
    public class ExperienceRepository
    {
        private readonly ApplicationContext _context;
        public ExperienceRepository(ApplicationContext context)
        {
            _context = context;
            /*Console.WriteLine("Me instanciaron");*/
        }

        public List<Experience> Get()
        {
            return _context.Experiences.ToList();
        }

        public int Add(Experience exp)
        {
            _context.Experiences.Add(exp);
            _context.SaveChanges();
            return exp.Id;
        }

        /*Al ser la clase estática no se pierden en memoria los datos*/
        /*public List<Experience> Experiences { get; set; } = new List<Experience>()
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
        };/*

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
