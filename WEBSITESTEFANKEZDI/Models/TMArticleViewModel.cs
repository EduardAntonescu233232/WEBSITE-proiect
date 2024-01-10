namespace WEBSITESTEFANKEZDI.Models
{
    public class TMModellingArticleViewModel
    {
        public Guid ArticleId { get; set; } 
        public string Title { get; set; }
        public string URL { get; set; }
        public int Type { get; set; }
        public string Content { get; set; } 
        public List<string> Images { get; set; }
    }
}
