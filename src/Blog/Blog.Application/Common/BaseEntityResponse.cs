using Blog.Domain.Common;

namespace Blog.Application.Common;
public abstract class BaseEntityResponse(BaseEntity entity)
{
    public Guid Id { get; set; } = entity.Id;
    public DateTime CreatedAt { get; set; } = entity.CreatedAt;
    public DateTime? UpdatedAt { get; set; } = entity.UpdatedAt;
}
