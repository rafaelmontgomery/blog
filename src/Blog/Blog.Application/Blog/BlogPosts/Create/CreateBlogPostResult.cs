namespace Blog.Application.Blog.BlogPosts.Create;
public class CreateBlogPostResult(Guid id)
{
    public Guid Id { get; private set; } = id;
}
