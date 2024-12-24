using Api_One_Trick_Pony_Br.Data;
using Api_One_Trick_Pony_Br.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_One_Trick_Pony_Br.Services
{
    public static class PlatformServices
    {
        public static void MapPlatformEndpoints(this IEndpointRouteBuilder routes){

            var group = routes.MapGroup("/api/Platform").WithTags(nameof(Platform));

            group.MapGet("/", async (ApiContext service) =>
            {
                return await service.Platform.ToListAsync();
            })
            .WithName("GetAllPlatforms")
            .WithOpenApi();

            group.MapGet("/{id}", async (ApiContext service, int id) =>
            {
                var platform = await service.Platform.FindAsync(id);
                if (platform is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(platform);
            })
            .WithName("GetPlatformById")
            .WithOpenApi();

            group.MapPost("/", async (ApiContext service, Platform platform) =>
            {
                service.Platform.Add(platform);
                await service.SaveChangesAsync();
                return Results.Created($"/api/Platform/{platform.Id}", platform);
            })
            .WithName("CreatePlatform")
            .WithOpenApi();

            group.MapPut("/{id}", async (ApiContext service, int id, Platform platform) =>
            {
                if (id != platform.Id)
                {
                    return Results.BadRequest();
                }
                service.Entry(platform).State = EntityState.Modified;
                await service.SaveChangesAsync();
                return Results.NoContent();
            })
            .WithName("UpdatePlatform")
            .WithOpenApi();

            group.MapDelete("/{id}", async (ApiContext service, int id) =>
            {
                var delete = service.Platform.SingleOrDefault(platform => platform.Id == id);
                if (delete == null)
                    return Results.NotFound();

                var platform = service.Platform.Remove(delete);
                await service.SaveChangesAsync();
                return Results.Ok(platform);
            })
            .WithName("DeletePlatform")
            .WithOpenApi();
        }
    }
}
