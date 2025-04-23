using System.Xml.Linq;

namespace BlogApi.Domain
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<Comment> Comments { get; set; } = new();
    }

}
