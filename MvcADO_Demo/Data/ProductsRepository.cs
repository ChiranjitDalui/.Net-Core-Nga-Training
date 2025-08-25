using System.Data;
using Microsoft.Data.SqlClient;
namespace MvcADO_Demo.Data;

public class ProductsRepository
{
    private readonly IDbConnection _dbConnection;

    public ProductsRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public int InsertProduct(string name, decimal price)
    {
        using var connection = _dbConnection;
        using var command = connection.CreateCommand();
        
        command.CommandText = "INSERT INTO Products (Name, Price) VALUES (@name, @price); SELECT SCOPE_IDENTITY();";
        command.Parameters.Add(new SqlParameter("@name", name));
        command.Parameters.Add(new SqlParameter("@price", price));
        
        connection.Open();
        var result = command.ExecuteScalar();
        
        return Convert.ToInt32(result);
    }

    public DataSet GetProducts()
    {
        var dataSet = new DataSet();
        using var connection = _dbConnection;
        using var command = connection.CreateCommand();
        
        command.CommandText = "SELECT * FROM Products";
        using var adapter = new SqlDataAdapter((SqlCommand)command);
        
        adapter.Fill(dataSet);
        return dataSet;
    }
    
    public int DeleteProduct(int productId)
    {
        using var connection = _dbConnection;
        using var command = connection.CreateCommand();

        command.CommandText = "DELETE FROM Products WHERE ProductID = @productId";
        command.Parameters.Add(new SqlParameter("@productId", productId));

        connection.Open();
        var result = command.ExecuteNonQuery();
        
        return result;
    }
}