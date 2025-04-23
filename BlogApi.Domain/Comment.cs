namespace BlogApi.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int BlogPostId { get; set; }
        public BlogPost? BlogPost { get; set; }
    }

}
