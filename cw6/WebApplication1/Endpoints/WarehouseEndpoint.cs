using FluentValidation;
using WebApplication1.DTOs;
using WebApplication1.Services;
using WebApplication1.Validators;

namespace WebApplication1.EndPoints;

public static class WarehouseEndpoint
{
    public static void RegisterWarehouseEndpoint(this WebApplication app)
    {
        app.MapPost("api/WarehouseAddProduct", WarehouseProductAdd);
    }

    /*public static async Task<IResult> WarehouseProductAdd(
        WarehouseProductDTO request, IService service, IValidator<WarehouseProductValidator> validator
    )*/
    public static async Task<IResult> WarehouseProductAdd(
        WarehouseProductDTO request, IService service
    )
    {
        /*var context = new ValidationContext<object>(request);
        var validate = validator.Validate(context);
        if (!validate.IsValid)
        {
            return Results.ValidationProblem(validate.ToDictionary());
        }*/

        var product = await service.GetProductById(request.IdProduct);

        if (product is null) return Results.NotFound($"Wrong IdProduct: {request.IdProduct}");

        var warehouse = await service.GetWarehouseById(request.IdWarehouse);

        if (warehouse is null) return Results.NotFound($"Wrong IdWarehouse: {request.IdWarehouse}");

        var order = await service.GetOrderByIdProductAndAmount(request.IdProduct, request.Amount);

        if (order is null)
            return Results.NotFound(
                $"There is no order with IdProduct: {request.IdWarehouse} and Amount: {request.Amount} ");

        if (order.CreatedAt > request.CreatedAt) return Results.Conflict($"Order was created after request");

        var productWarehouseElementById = await service.GetProductWarehouseByOrder(order.IdOrder);

        if (productWarehouseElementById is not null)
            return Results.Conflict($"IdOrder: {order.IdOrder} is already in warehouse");

        var addedProductWarehouseElementId = await service.AddProductWarehouse(request.IdProduct, product.Price,
            request.IdWarehouse, order.IdOrder, request.Amount);

        return Results.Created("", addedProductWarehouseElementId);
    }
}