using Api_One_Trick_Pony_Br.Data;
using Api_One_Trick_Pony_Br.Models;
using Api_One_Trick_Pony_Br.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api_One_Trick_Pony_Br.Services
{
    public static class PlatformServices
    {
        public static void MapPlatformEndpoints(this IEndpointRouteBuilder routes){

            var group = routes.MapGroup("/api/Platform").WithTags(nameof(Platform));

            group.MapGet("/", async (PlatformRepository repo) =>
            {
                return await repo.GetAllAsync();
            })
            .WithName("GetAllPlatforms")
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
                repo.AddAsync(platform);

                return Results.Created($"/api/Platform/{platform.Id}", platform);
            })
            .WithName("CreatePlatform")
            .WithOpenApi();

            group.MapPut("/{id}", async (PlatformRepository repo, int id, Platform platform) =>
            {
                platform = await repo.GetByIdAsync(id);

                if (id != platform.Id)
                    return Results.BadRequest();

                await repo.UpdateAsync(platform);
                return Results.Ok();
            })
            .WithName("UpdatePlatform")
            .WithOpenApi();

            group.MapDelete("/{id}", async (PlatformRepository repo, int id) =>
            {
                var delete = repo.DeleteAsync(id) ;
                if (delete == null)
                    return Results.NotFound();

                return Results.Ok();
            })
            .WithName("DeletePlatform")
            .WithOpenApi();
        }
    }
}
