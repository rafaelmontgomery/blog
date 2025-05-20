namespace Blog.Application.Blog.BlogPosts.Update;
public class UpdateBlogPostResult(Guid id)
{
    public Guid Id { get; private set; } = id;
}
