namespace Blog.Application.Identity.Users.Create;
public class CreateUserResult(Guid id)
{
    public Guid Id { get; private set; } = id;
}