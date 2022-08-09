using Npgsql;

namespace ConsoleApp3for300bot;

public class DBfoods
{
    private const string connectionString =
        "Host=194.67.105.79;Username=vladpidruser;Password=0;Database=vladpidrdb";

    private Random _random;

    private NpgsqlConnection _connection;
    
    public DBfoods()
    {
        _random = new Random();

        _connection = new NpgsqlConnection(connectionString);
        _connection.Open();
    }

    private int GetMaxId()
    {
        string sqlRequest = "SELECT max(id) FROM foods";
        NpgsqlCommand command = new NpgsqlCommand(sqlRequest, _connection);

        int maxId = int.Parse(command.ExecuteScalar().ToString());

        return maxId;
    }
    
    private int GetMaxIdDrink()
    {
        string sqlRequest = "SELECT max(id) FROM drinks";
        NpgsqlCommand command = new NpgsqlCommand(sqlRequest, _connection);

        int maxId = int.Parse(command.ExecuteScalar().ToString());

        return maxId;
    }
    
    private int GetMaxIdDessert()
    {
        string sqlRequest = "SELECT max(id) FROM desserts";
        NpgsqlCommand command = new NpgsqlCommand(sqlRequest, _connection);

        int maxId = int.Parse(command.ExecuteScalar().ToString());

        return maxId;
    }

    public string GetRandomFood()
    {
        int maxId = GetMaxId();

        Object sqlResponse = null;

        do
        {
            int randomId = _random.Next(1, maxId + 1);
            string sqlRequest = $"SELECT food_notes FROM foods WHERE id={randomId}";
            NpgsqlCommand command = new NpgsqlCommand(sqlRequest, _connection);
            sqlResponse = command.ExecuteScalar();
        } while (sqlResponse == null);

        string foodText = sqlResponse.ToString();

        return foodText;
    }
    
    public string GetRandomDrink()
    {
        int maxId = GetMaxId();

        Object sqlResponse = null;

        do
        {
            int randomId = _random.Next(1, maxId + 1);
            string sqlRequest = $"SELECT drink_notes FROM drinks WHERE id={randomId}";
            NpgsqlCommand command = new NpgsqlCommand(sqlRequest, _connection);
            sqlResponse = command.ExecuteScalar();
        } while (sqlResponse == null);

        string drinkDrink = sqlResponse.ToString();

        return drinkDrink;
    }
    
    public string GetRandomDessert()
    {
        int maxId = GetMaxId();

        Object sqlResponse = null;

        do
        {
            int randomId = _random.Next(1, maxId + 1);
            string sqlRequest = $"SELECT dessert_notes FROM desserts WHERE id={randomId}";
            NpgsqlCommand command = new NpgsqlCommand(sqlRequest, _connection);
            sqlResponse = command.ExecuteScalar();
        } while (sqlResponse == null);

        string drinkDessert = sqlResponse.ToString();

        return drinkDessert;
    }
}