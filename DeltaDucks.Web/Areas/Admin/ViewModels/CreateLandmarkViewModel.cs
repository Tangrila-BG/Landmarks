﻿namespace DeltaDucks.Web.Areas.Admin.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class CreateLandmarkViewModel
    {
        [Required]
        [Display(Name="Име")]
        [StringLength(100, ErrorMessage = "{0}то трябва да бъде поне {2} знака.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Номер")]
        [Range(0, int.MaxValue)]
        public int Number { get; set; }

        [Display(Name = "Описание")]
        [StringLength(500, ErrorMessage = "{0}то трябва да бъде поне {2} знака.")]
        public string Description { get; set; }

        [Display(Name = "Информация")]
        [StringLength(int.MaxValue)]
        public string Information { get; set; }

        [Display(Name = "Снимки")]
        public ICollection<byte[]> Pictures { get; set; }

        [Required]
        [Display(Name = "Точки")]
        public int Points { get; set; }

        [Required]
        [Column(TypeName = "nchar(5)")]
        [Display(Name = "Уникален код")]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Географска ширина")]
        public float Latitude { get; set; }

        [Required]
        [Display(Name = "Географска дължина")]
        public float Longitude { get; set; }

        [Required]
        [Display(Name="Град")]
        public string Town { get; set; }
    }
}