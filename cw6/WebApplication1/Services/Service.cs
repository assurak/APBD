using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class Service(IConfiguration configuration) : IService
{
    private async Task<SqlConnection> GetConnection()
    {
        var connection = new SqlConnection(configuration.GetConnectionString("Default"));
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        return connection;
    }

    public async Task<Product?> GetProductById(int idProduct)
    {
        await using var connection = await GetConnection();
        var result = await connection.QueryFirstOrDefaultAsync<Product>(
            "select * from Product where IdProduct = @IdProduct",
            new { IdProduct = idProduct });
        return result;
    }

    public async Task<Warehouse?> GetWarehouseById(int idWarehouse)
    {
        await using var connection = await GetConnection();
        var result = await connection.QueryFirstOrDefaultAsync<Warehouse>(
            "select * from Warehouse where IdWarehouse = @IdWarehouse",
            new { IdWarehouse = idWarehouse });
        return result;
    }

    public async Task<Order?> GetOrderByIdProductAndAmount(int idProduct, int amount)
    {
        await using var connection = await GetConnection();
        var result = await connection.QueryFirstOrDefaultAsync<Order>(
            "select * from [Order] where IdProduct = @IdProduct and Amount = @Amount",
            new { IdProduct = idProduct, Amount = amount });
        return result;
    }

    public async Task<Product_Warehouse?> GetProductWarehouseByOrder(int idOrder)
    {
        await using var connection = await GetConnection();
        var result = await connection.QueryFirstOrDefaultAsync<Product_Warehouse>(
            "select * from Product_Warehouse where IdOrder = @IdOrder",
            new { IdOrder = idOrder });
        return result;
    }

    public async Task<int> AddProductWarehouse(int idProduct, float productPrice, int idWarehouse, int idOrder,
        int amount)
    {
        await using var connection = await GetConnection();
        await using var transaction = await connection.BeginTransactionAsync();
        try
        {
            DateTime currentTime = DateTime.Now;
            var affectedRows = await connection.ExecuteAsync(
                "update [Order] set FulfilledAt = @CurrentTime where IdOrder=@IdOrder",
                new
                {
                    CurrentTime = currentTime,
                    IdOrder = idOrder
                }, transaction: transaction);

            var productWarehousePrice = productPrice * amount;

            var productWarehouseId =
                await connection.ExecuteScalarAsync<int>(
                    "insert into Product_Warehouse values (@IdWarehouse, @IdProduct, @IdOrder, @Amount, @Price, @CreatedAt);" +
                    "select CAST(SCOPE_IDENTITY() as int)",
                    new
                    {
                        IdWarehouse = @idWarehouse,
                        IdProduct = @idProduct,
                        IdOrder = @idOrder,
                        Amount = @amount,
                        Price = @productWarehousePrice,
                        CreatedAt = @currentTime
                    }, transaction: transaction);

            await transaction.CommitAsync();
            return productWarehouseId;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}