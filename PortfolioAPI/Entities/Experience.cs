﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioAPI.Entities
{
    public class Experience
    {
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descripcion { get; set; }
        public string Summary { get; set; }
        public string ImgPath { get; set; }
        public string State { get; set; } = "Active";
    }
}
