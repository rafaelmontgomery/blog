namespace Blog.Application.Identity.Users.Create;
public class CreateUserResult
{
    public CreateUserResult(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}