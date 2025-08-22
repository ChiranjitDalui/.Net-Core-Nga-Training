namespace Day29_BlogDemo.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // Slug for user-friendly URL
        public string Slug { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}