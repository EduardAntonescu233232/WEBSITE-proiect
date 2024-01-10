namespace WEBSITESTEFANKEZDI.Models
{
    public class ArticleDetailsViewModel
    {
        public Guid ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Images { get; set; }

        public string FirstImagePath { get; set; }
    }
}
