namespace Blog.Application.Blog.BlogPosts.Create;
public class CreateBlogPostRequest
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public CreateBlogPostCommand ToCommand(Guid authorId) => new(Title, Content, authorId);
}
