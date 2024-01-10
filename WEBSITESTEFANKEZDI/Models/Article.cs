using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WEBSITESTEFANKEZDI.Models
{
    public class Article
    {
        [Key]
        public Guid ArticleId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set;}

        public string? URL { get; set;}

        [Required]
        public ArticleType Type { get; set;}

        public List<ArticleImage> Images { get; set; }
    }
}
