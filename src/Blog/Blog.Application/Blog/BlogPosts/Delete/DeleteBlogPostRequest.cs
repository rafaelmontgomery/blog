namespace Blog.Application.Blog.BlogPosts.Delete;
public class DeleteBlogPostRequest
{
    public Guid Id { get; set; }

    public DeleteBlogPostCommand ToCommand() => new(Id);
}
