namespace Blog.Domain.Interfaces;
public interface ISoftDeletable
{
    public DateTime? DeletedAt { get; protected set; }
    public Guid? DeletedBy { get; protected set; }

    public void SetDeletedAt(DateTime deletedAt);
    public void SetDeletedBy(Guid deletedBy);
}
