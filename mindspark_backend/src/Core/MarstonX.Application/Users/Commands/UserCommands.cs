namespace MarstonX.Application.Users.Commands;

public class CreateUserCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class UpdateUserCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class DeleteUserCommand : IRequest<bool>
{
    public int Id { get; set; }
    
    public DeleteUserCommand(int id)
    {
        Id = id;
    }
}