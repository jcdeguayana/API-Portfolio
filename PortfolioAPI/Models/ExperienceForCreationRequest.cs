using System.ComponentModel.DataAnnotations;

namespace PortfolioAPI.Models
{
    public class ExperienceForCreationAndUpdateRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }

        [Required]
        [Url]
        public string ImagePath { get; set; }
    }
}
