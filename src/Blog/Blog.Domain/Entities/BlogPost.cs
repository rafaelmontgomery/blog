using Blog.Domain.Common;

namespace Blog.Domain.Entities;
public class BlogPost : BaseEntity
{
    public string Title { get; private set; } = string.Empty;
    public string Content { get; private set; } = string.Empty;
    public Guid AuthorId { get; private set; }
    public User Author { get; set; } = null!;

    public static BlogPost Create(string title, string content, Guid authorId)
    {
        var blogPost = new BlogPost(title, content, authorId);
        return blogPost;
    }

    public void Edit(string newTitle, string newContent)
    {
        SetTitle(newTitle);
        SetContent(newContent);
        SetUpdatedAt();
    }

    public void SetTitle(string title) => Title = title;
    public void SetContent(string content) => Content = content;

    private BlogPost() { }

    private BlogPost(string title, string content, Guid authorId)
    {
        Id = Guid.NewGuid();
        Title = title;
        Content = content;
        AuthorId = authorId;
        CreatedAt = DateTime.UtcNow;
    }

}
