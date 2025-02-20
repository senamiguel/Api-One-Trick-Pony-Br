using Api_One_Trick_Pony_Br.Models;
using Api_One_Trick_Pony_Br.Repository;

namespace Api_One_Trick_Pony_Br.Services
{
    public static class AccountService
    {
        public static void MapAccountEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Account").WithTags(nameof(Account));

            group.MapGet("/", async (AccountRepository repo) =>
            {
                return await repo.GetAllAsync();
            })
            .WithName("GetAllAccount")
            .WithOpenApi();

            group.MapGet("/{id}" , async (AccountRepository repo, int id) =>
            {
                var account = await repo.GetByIdAsync(id);
                if (account is null)
                    return Results.NotFound();

                return Results.Ok(account);
            })
            .WithName("GetOneAccount")
            .WithOpenApi();

            group.MapPost("/", async (AccountRepository repo, Account account) =>
            {
                await repo.AddAsync(account);

                return Results.Created($"/api/Account/{account.Id}", account);
            })
            .WithName("CreateAccount")
            .WithOpenApi();

            group.MapPut("/{id}", async (AccountRepository repo, int id, Account update) =>
            {
                await repo.UpdateAsync(update, id);
            })
            .WithName("UpdateAccount")
            .WithOpenApi();

            group.MapDelete("/{id}", async (AccountRepository repo, int id) =>
            {
                await repo.DeleteAsync(id);
            })
            .WithName("DeleteAccount")
            .WithOpenApi();
        }
    }
}
