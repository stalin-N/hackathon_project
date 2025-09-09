namespace MarstonX.Application.Users.Queries;

public class GetAllUsersQuery : IRequest<IEnumerable<User>>
{
}

public class GetUserQuery : IRequest<User?>
{
    public int Id { get; set; }
    
    public GetUserQuery(int id)
    {
        Id = id;
    }
}