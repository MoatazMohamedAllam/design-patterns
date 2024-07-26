namespace specification.Data;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; } = DateTime.Now;
    public List<Comment> Comments { get; set; }
}