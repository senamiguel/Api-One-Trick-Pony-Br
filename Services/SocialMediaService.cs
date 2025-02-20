using Api_One_Trick_Pony_Br.Data;
using Api_One_Trick_Pony_Br.Models;
using Api_One_Trick_Pony_Br.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api_One_Trick_Pony_Br.Services
{
    public static class SocialMediaService
    {
        public static void MapSocialMediaEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/SocialMedia").WithTags(nameof(SocialMedia));

            group.MapGet("/", async (SocialMediaRepository repo) =>
            {
                return await repo.GetAllAsync();
            })
            .WithName("GetAllSocialMedias")
            .WithOpenApi();

            group.MapGet("/{id}", async (SocialMediaRepository repo, int id) =>
            {
                var socialMedia = await repo.GetByIdAsync(id);
                if (socialMedia is null)
                    return Results.NotFound();

                return Results.Ok(socialMedia);
            })
            .WithName("GetSocialMediaById")
            .WithOpenApi();

            group.MapPost("/", async (SocialMediaRepository repo, SocialMedia socialMedia) =>
            {
                await repo.AddAsync(socialMedia);

                return Results.Created($"/api/SocialMedia/{socialMedia.Id}", socialMedia);
            })
            .WithName("CreateSocialMedia")
            .WithOpenApi();

            group.MapPut("/{id}", async (SocialMediaRepository repo, int id, SocialMedia socialMedia) =>
            {
                await repo.UpdateAsync(socialMedia, id);
            })
            .WithName("UpdateSocialMedia")
            .WithOpenApi();

            group.MapDelete("/{id}", async (SocialMediaRepository repo, int id) =>
            {
                await repo.DeleteAsync(id);
            })
            .WithName("DeleteSocialMedia")
            .WithOpenApi();
        }
    }
}
