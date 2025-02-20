using Api_One_Trick_Pony_Br.Data;
using Api_One_Trick_Pony_Br.Models;
using Api_One_Trick_Pony_Br.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_One_Trick_Pony_Br.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApiContext _context;

        public CommentRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comment.FindAsync(id);
        }

        public async Task AddAsync(Comment comment)
        {
            await _context.Comment.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comment comment, int id)
        {
            _context.Comment.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await _context.Comment.FindAsync(id);

            if (comment is null)
                Results.NotFound();

            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();
            Results.Ok();
        }
    }
}
