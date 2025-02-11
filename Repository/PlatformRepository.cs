using Api_One_Trick_Pony_Br.Data;
using Api_One_Trick_Pony_Br.Models;
using Api_One_Trick_Pony_Br.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_One_Trick_Pony_Br.Repository
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly ApiContext _context;

        public PlatformRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<Platform>> GetAllAsync()
        {
            return await _context.Platform.ToListAsync();
        }

        public async Task<Platform?> GetByIdAsync([FromBody] int id)
        {
            return await _context.Platform.FindAsync(id);
        }

        public async Task AddAsync([FromBody] Platform platform)
        {
            await _context.Platform.AddAsync(platform);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync([FromBody] Platform platform)
        {
            _context.Platform.Update(platform);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync([FromBody] int id)
        {
            var platform = await GetByIdAsync(id);
            if (platform == null)
            {
                Results.NotFound();
            }
            _context.Platform.Remove(platform);
            await _context.SaveChangesAsync();
        }
    }
}
