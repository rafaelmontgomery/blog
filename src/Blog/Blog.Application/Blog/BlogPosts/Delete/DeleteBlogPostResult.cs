namespace Blog.Application.Blog.BlogPosts.Delete;
public class DeleteBlogPostResult(Guid id)
{
    public Guid Id { get; private set; } = id;
}
