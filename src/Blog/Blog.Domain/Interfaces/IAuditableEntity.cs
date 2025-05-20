namespace Blog.Domain.Interfaces;
internal interface IAuditableEntity
{

    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }

    public void SetUpdatedAt();

}
