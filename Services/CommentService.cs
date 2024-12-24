using Api_One_Trick_Pony_Br.Data;
using Api_One_Trick_Pony_Br.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_One_Trick_Pony_Br.Services
{
    public static class CommentService
    {
        public static void MapCommentEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Comment").WithTags(nameof(Comment));

            group.MapGet("/", async (ApiContext service) =>
            {
                return await service.Comment.ToListAsync();
            })
            .WithName("GetAllComments")
            .WithOpenApi();

            group.MapGet("/{id}", async (ApiContext service, int id) =>
            {
                var comment = await service.Comment.FindAsync(id);
                if (comment is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(comment);
            })
           .WithName("GetCommentById")
           .WithOpenApi();

            group.MapPost("/", async (ApiContext service, Comment comment) =>
            {
                service.Comment.Add(comment);
                await service.SaveChangesAsync();
                return Results.Created($"/api/Comment/{comment.Id}", comment);
            })
            .WithName("CreateComment")
            .WithOpenApi();

            group.MapPut("/{id}", async (ApiContext service, int id, Comment comment) =>
            {
                if (id != comment.Id)
                {
                    return Results.BadRequest();
                }
                service.Entry(comment).State = EntityState.Modified;
                await service.SaveChangesAsync();
                return Results.NoContent();
            })
            .WithName("UpdateComment")
            .WithOpenApi();

            group.MapDelete("/{id}", async (ApiContext service, int id) =>
            {
                var delete = service.Comment.SingleOrDefault(comment => comment.Id == id);

                if (delete == null)
                    return Results.NotFound();

                var comment = service.Comment.Remove(delete);
                service.SaveChanges();
                return Results.Ok(comment);
            })
            .WithName("DeleteComment")
            .WithOpenApi();
        }
    }
}
