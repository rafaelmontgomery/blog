using Blog.Domain.Interfaces;

namespace Blog.Domain.Common;
public abstract class BaseEntity : IAuditableEntity, ISoftDeletable
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
    public Guid? DeletedBy { get; set; }

    public void SetDeletedAt(DateTime deletedAt) => DeletedAt = deletedAt;
    public void SetDeletedBy(Guid deletedBy) => DeletedBy = deletedBy;
    public void SetUpdatedAt() => UpdatedAt = DateTime.UtcNow;

}
