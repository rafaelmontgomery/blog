namespace Blog.Domain.Interfaces;
internal interface ISoftDeletable
{
    public DateTime? DeletedAt { get; protected set; }
    public Guid? DeletedBy { get; protected set; }

    public void SetDeletedAt(DateTime deletedAt);
    public void SetDeletedBy(Guid deletedBy);
}
