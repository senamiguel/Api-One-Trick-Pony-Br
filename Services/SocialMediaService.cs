using Api_One_Trick_Pony_Br.Data;
using Api_One_Trick_Pony_Br.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_One_Trick_Pony_Br.Services
{
    public static class SocialMediaService
    {
        public static void MapSocialMediaEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/SocialMedia").WithTags(nameof(SocialMedia));

            group.MapGet("/", async (ApiContext service) =>
            {
                return await service.SocialMedia.ToListAsync();
            })
            .WithName("GetAllSocialMedias")
            .WithOpenApi();

            group.MapGet("/{id}", async (ApiContext service, int id) =>
            {
                var socialMedia = await service.SocialMedia.FindAsync(id);
                if (socialMedia is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(socialMedia);
            })
            .WithName("GetSocialMediaById")
            .WithOpenApi();

            group.MapPost("/", async (ApiContext service, SocialMedia socialMedia) =>
            {
                service.SocialMedia.Add(socialMedia);
                await service.SaveChangesAsync();
                return Results.Created($"/api/SocialMedia/{socialMedia.Id}", socialMedia);
            })
            .WithName("CreateSocialMedia")
            .WithOpenApi();

            group.MapPut("/{id}", async (ApiContext service, int id, SocialMedia socialMedia) =>
            {
                if (id != socialMedia.Id)
                {
                    return Results.BadRequest();
                }
                service.Entry(socialMedia).State = EntityState.Modified;
                await service.SaveChangesAsync();
                return Results.NoContent();
            })
            .WithName("UpdateSocialMedia")
            .WithOpenApi();

            group.MapDelete("/{id}", async (ApiContext service, int id) =>
            {
                var delete = service.SocialMedia.SingleOrDefault(socialMedia => socialMedia.Id == id);
                if (delete == null)
                    return Results.NotFound();

                var media = service.SocialMedia.Remove(delete);
                await service.SaveChangesAsync();
                return Results.Ok(media);
            })
            .WithName("DeleteSocialMedia")
            .WithOpenApi();
        }
    }
}
