using cw10.Exceptions;
using cw10.RequestModels;
using cw10.Services;
using Microsoft.AspNetCore.Mvc;

namespace cw10.Endpoints;

public static class ProductEndpoint
{
    public static void RegisterProductEndpoint(this RouteGroupBuilder build)
    {
        var group = build.MapGroup("products");

        group.MapPost("", AddProduct);
    }

    private static async Task<IResult> AddProduct(AddProductRequestModel addProductRequestModel,
        [FromServices] IProductService service)
    {
        try
        {
            var productResponse = await service.AddProduct(addProductRequestModel);
            return Results.Created($"/api/products/{productResponse.productName}", productResponse);
        }
        catch (ProductConflictException e)
        {
            return Results.Conflict(e.Message);
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }
}