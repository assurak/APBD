using cw10.Contexts;
using cw10.Exceptions;
using cw10.Models;
using cw10.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace cw10.Services;

public interface IAccountService
{
    Task<GetAccountResponseModel> GetAccountByIdAsync(int id);
}

public class AccountService (DatabaseContext context): IAccountService
{
    public async Task<GetAccountResponseModel> GetAccountByIdAsync(int id)
    {
        var result = await context.Accounts
            .Where(e => e.AccountId == id)
            .Select(e => new GetAccountResponseModel()
            {
                firstName = e.FirstName,
                lastName = e.LastName,
                email = e.Email,
                phone = e.Phone,
                role = e.Role.Name,
                cart = e.ShoppingCarts.Select(sc => new CartResponseModel()
                {
                    productId = sc.ProductId,
                    productName = sc.Product.Name,
                    amount = sc.Amount 
                }).ToList()
                
            })
            .FirstOrDefaultAsync();
        if (result is null)
        {
            throw new NotFoundException($"There is no account with id:{id}");
        }

        return result;
    }
}