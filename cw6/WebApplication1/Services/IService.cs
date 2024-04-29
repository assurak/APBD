using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IService
{
    Task<Product?> GetProductById(int idProduct);
    Task<Warehouse?> GetWarehouseById(int idWarehouse);
    Task<Order?> GetOrderByIdProductAndAmount(int idProduct, int amount);
    Task<Product_Warehouse?> GetProductWarehouseByOrder(int idOrder);
    Task<int> AddProductWarehouse(int idProduct,float productPrice ,int idWarehouse, int idOrder, int amount);
}