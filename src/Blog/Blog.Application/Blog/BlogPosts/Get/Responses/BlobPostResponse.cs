using Blog.Application.Common;
using Blog.Domain.Entities;

namespace Blog.Application.Blog.BlogPosts.Get.Responses;
public class BlobPostResponse : BaseEntityResponse
{
    public string Title { get; private set; }
    public string Content { get; private set; }
    public string Author { get; private set; }

    private BlobPostResponse(BlogPost blogPost) : base(blogPost)
    {
        Title = blogPost.Title;
        Content = blogPost.Content;
        Author = blogPost.Author.Username;
    }

    public static BlobPostResponse Create(BlogPost blogPost)
    {
        return blogPost == null ? null! : new(blogPost);
    }

    public static IEnumerable<BlobPostResponse> Create(IEnumerable<BlogPost> blogPosts)
    {
        return blogPosts.Select(Create);
    }
}
