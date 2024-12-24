using Api_One_Trick_Pony_Br.Data;
using Api_One_Trick_Pony_Br.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_One_Trick_Pony_Br.Services
{
    public static class PonyService
    {
        public static void MapPonyEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Pony").WithTags(nameof(Pony));

            group.MapGet("/", async (ApiContext service) =>
            {
                return await service.Pony.ToListAsync();

            })
            .WithName("GetAllPonys")
            .WithOpenApi();

            group.MapGet("/{id}", async (ApiContext service, int id) =>
            {
                var pony = await service.Pony.FindAsync(id);
                if (pony is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(pony);
            })
           .WithName("GetPonyById")
           .WithOpenApi();

            group.MapPost("/", async (ApiContext service, Pony pony) =>
            {
                service.Pony.Add(pony);
                await service.SaveChangesAsync();
                return Results.Created($"/api/Pony/{pony.Id}", pony);
            })
            .WithName("CreatePony")
            .WithOpenApi();

            group.MapPut("/{id}", async (ApiContext service, int id, Pony pony) =>
            {
                if (id != pony.Id)
                {
                    return Results.BadRequest();
                }
                service.Entry(pony).State = EntityState.Modified;
                await service.SaveChangesAsync();
                return Results.NoContent();
            })
            .WithName("UpdatePony")
            .WithOpenApi();

            group.MapDelete("/{id}", async (ApiContext service, int id) =>
            {
                var delete = service.Pony.SingleOrDefault(pony => pony.Id == id);

                if (delete == null)
                    return Results.NotFound();

                var pony = service.Pony.Remove(delete);
                service.SaveChanges();
                return Results.Ok(pony);

            })
            .WithName("DeletePony")
            .WithOpenApi();
        }
    }
}
