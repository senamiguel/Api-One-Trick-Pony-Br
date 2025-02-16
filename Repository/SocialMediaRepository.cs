using Api_One_Trick_Pony_Br.Data;
using Api_One_Trick_Pony_Br.Models;
using Api_One_Trick_Pony_Br.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api_One_Trick_Pony_Br.Repository
{
    public class SocialMediaRepository : ISocialMediaRepository
    {
        private readonly ApiContext _context;

        public SocialMediaRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<SocialMedia>> GetAllAsync()
        {
            return await _context.SocialMedia.ToListAsync();
        }

        public async Task<SocialMedia?> GetByIdAsync(int id)
        {
            return await _context.SocialMedia.FindAsync(id);
        }

        public async Task AddAsync(SocialMedia socialMedia)
        {
            await _context.SocialMedia.AddAsync(socialMedia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SocialMedia socialMedia)
        {
            _context.SocialMedia.Update(socialMedia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var socialMedia = await GetByIdAsync(id);
            if (socialMedia == null)
            {
                Results.NotFound();
            }
            _context.SocialMedia.Remove(socialMedia);
            await _context.SaveChangesAsync();
        }
    }
}
