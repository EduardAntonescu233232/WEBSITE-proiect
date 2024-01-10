using System.ComponentModel.DataAnnotations;

namespace WEBSITESTEFANKEZDI.Models
{
    public class ArticleImage
    {
        [Key]
        public Guid ArticleImageId { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public Guid ArticleId { get; set; }

        public Article Article { get; set; }

    }
}
