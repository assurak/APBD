using cw10.Contexts;
using cw10.Exceptions;
using cw10.Models;
using cw10.RequestModels;
using cw10.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace cw10.Services;

public interface IProductService
{
    Task<AddProductResponseModel> AddProduct(AddProductRequestModel addProductRequestModel);
}

public class ProductService(DatabaseContext context) : IProductService
{
    public async Task<AddProductResponseModel> AddProduct(AddProductRequestModel addProductRequestModel)
    {
        var product = new Product
        {
            Name = addProductRequestModel.productName,
            Weight = addProductRequestModel.productWeight,
            Width = addProductRequestModel.productWidth,
            Height = addProductRequestModel.productHeight,
            Depth = addProductRequestModel.productDepth
        };
        var categoriesId = addProductRequestModel.categoriesId;

        bool productExists = await context.Products.AnyAsync(p => p.Name == addProductRequestModel.productName);

        if (productExists)
        {
            throw new ProductConflictException($"There is already product with such name");
        }
        
        foreach (var categoryId in categoriesId)
        {
            bool categoryExists = await context.Categories.AnyAsync(c => c.CategoryId == categoryId);
            if (!categoryExists)
            {
                throw new ProductConflictException($"Category with id {categoryId} does not exist");
            }
        }
        
        await using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            foreach (var categoryId in categoriesId)
            {
                await context.ProductsCategories.AddAsync(new ProductCategory()
                {
                    ProductId = product.ProductId,
                    CategoryId = categoryId
                });
            }

            await context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }

        return new AddProductResponseModel()
        {
            productName = product.Name,
            productWeight = product.Weight,
            productWidth = product.Width,
            productHeight = product.Height,
            productDepth = product.Depth,
            categoriesId = categoriesId
        };
    }
}