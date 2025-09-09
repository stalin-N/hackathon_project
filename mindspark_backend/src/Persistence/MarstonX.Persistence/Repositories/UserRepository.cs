namespace MarstonX.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DapperContext _context;
    
    public UserRepository(DapperContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        using var connection = _context.CreateConnection();
        const string sql = "SELECT * FROM Users";
        return await connection.QueryAsync<User>(sql);
    }
    
    public async Task<User?> GetByIdAsync(int id)
    {
        using var connection = _context.CreateConnection();
        const string sql = "SELECT * FROM Users WHERE Id = @Id";
        return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
    }
    
    public async Task<int> CreateAsync(User user)
    {
        using var connection = _context.CreateConnection();
        const string sql = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email); SELECT CAST(SCOPE_IDENTITY() as int)";
        return await connection.QuerySingleAsync<int>(sql, user);
    }
    
    public async Task<bool> UpdateAsync(User user)
    {
        using var connection = _context.CreateConnection();
        const string sql = "UPDATE Users SET Name = @Name, Email = @Email WHERE Id = @Id";
        var affectedRows = await connection.ExecuteAsync(sql, user);
        return affectedRows > 0;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = _context.CreateConnection();
        const string sql = "DELETE FROM Users WHERE Id = @Id";
        var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
        return affectedRows > 0;
    }
}

public class UserMongoRepository : IUsermongoRepository
{
    private readonly MongoContext _context;
    
    public UserMongoRepository(MongoContext context)
    {
        _context = context;
    }
}