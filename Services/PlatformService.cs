using Api_One_Trick_Pony_Br.Models;
using Api_One_Trick_Pony_Br.Repository;

namespace Api_One_Trick_Pony_Br.Services
{
    public static class PlatformService
    {
        public static void MapPlatformEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Platform").WithTags(nameof(Platform));

            group.MapGet("/", async (PlatformRepository repo) =>
            {
                return await repo.GetAllAsync();
            })
            .WithName("GetAllPlatform")
            .WithOpenApi();

            group.MapGet("/{id}", async (PlatformRepository repo, int id) =>
            {
                var platform = await repo.GetByIdAsync(id);
                if (platform is null)
                    return Results.NotFound();

                return Results.Ok(platform);
            })
           .WithName("GetPlatformById")
           .WithOpenApi();

            group.MapPost("/", async (PlatformRepository repo, Platform platform) =>
            {
                await repo.AddAsync(platform);

                if (platform == null)
                    return Results.BadRequest();

                return Results.Created();
            })
            .WithName("CreatePlatform")
            .WithOpenApi();

            group.MapPut("/{id}", async (PlatformRepository repo, int id, Platform update) =>
            {
                await repo.UpdateAsync(update, id);
            })
            .WithName("UpdatePlatform")
            .WithOpenApi();

            group.MapDelete("/{id}", async (PlatformRepository repo, int id) =>
            {
                await repo.DeleteAsync(id);
            })
            .WithName("DeletePlatform")
            .WithOpenApi();
        }
    }
}
