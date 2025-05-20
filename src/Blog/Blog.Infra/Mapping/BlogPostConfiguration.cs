using Blog.Domain.Entities;
using Blog.Infra.Mapping.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infra.Mapping;
public class BlogPostConfiguration : BaseEntityTypeConfiguration<BlogPost>
{
    public override void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        base.Configure(builder);

        builder.Property(u => u.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Content)
            .IsRequired()
            .HasMaxLength(2000);

        builder.HasOne(bp => bp.Author)
            .WithMany(u => u.BlogPosts)
            .HasForeignKey(bp => bp.AuthorId);

    }
}
