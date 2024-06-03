using cw10.Exceptions;
using cw10.Services;
using Microsoft.AspNetCore.Mvc;

namespace cw10.Endpoints;

public static class AccountEndpoint
{
    public static void RegisterAccountEndpoint(this RouteGroupBuilder build)
    {
        var group = build.MapGroup("accounts");

        group.MapGet("{idAccount:int}", GetAccountById);
    }

    private static async Task<IResult> GetAccountById([FromRoute] int idAccount, [FromServices] IAccountService service)
    {
        try
        {
            var account = await service.GetAccountByIdAsync(idAccount);
            if (account == null)
            {
                return Results.NotFound("Account not found.");
            }
            return Results.Ok(account);
        }
        catch (NotFoundException e)
        {
            return Results.NotFound(e.Message);
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }
}