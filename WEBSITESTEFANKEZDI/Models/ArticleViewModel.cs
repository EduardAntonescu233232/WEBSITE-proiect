using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using WEBSITESTEFANKEZDI.Data.Migrations;
using WEBSITESTEFANKEZDI.Models;

namespace WEBSITESTEFANKEZDI.ViewModels
{
    public class ArticleViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Title:")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Content:")]
        [Required]
        public string Content { get; set; }

        [Display(Name = "URL:")]
        public string? URL { get; set; }

        [Display(Name = "Type:")]
        [Required]
        public Models.ArticleType ArticleType { get; set; }

        [Display(Name = "Images:")]
        [Required(ErrorMessage = "Please select at least one image.")]
        public List<IFormFile> Images { get; set; }
    }
}
