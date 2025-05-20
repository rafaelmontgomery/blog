namespace Blog.Application.Blog.BlogPosts.Update;
public class UpdateBlogPostRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public UpdateBlogPostCommand ToCommand(Guid authorId) => new(Id, Title, Content, authorId);
}
