namespace MarstonX.Persistence.Data;

public class DapperContext
{
    private readonly IConfiguration _configuration;
    
    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IDbConnection CreateConnection()
        => new SqlConnection(_configuration.GetConnectionString("SqlConnection"));
}

public class MongoContext
{
    private readonly IMongoDatabase _database;
    
    public MongoContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoConnection"));
        _database = client.GetDatabase("MarstonX");
    }
    
    public IMongoCollection<T> GetCollection<T>(string collectionName)
        => _database.GetCollection<T>(collectionName);
}