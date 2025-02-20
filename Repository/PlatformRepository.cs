using Api_One_Trick_Pony_Br.Data;
using Api_One_Trick_Pony_Br.Models;
using Api_One_Trick_Pony_Br.Repository.Interfaces;
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

        public async Task<Platform?> GetByIdAsync(int id)
        {
            return await _context.Platform.FindAsync(id);
           
        }

        public async Task AddAsync(Platform platform)
        {
            await _context.Platform.AddAsync(platform);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Platform update, int id)
        {
            var platform = await _context.Platform.FindAsync(id);

            if (platform is null) 
                Results.BadRequest("Plataforma não encontrada.");

            platform.Image = update.Image;
            platform.Name = update.Name;
            
            await _context.SaveChangesAsync();
            Results.Ok(platform);
        }

        public async Task DeleteAsync(int id)
        {
            var platform = await _context.Platform.FindAsync(id);

            if (platform is null)
                Results.NotFound();

            _context.Platform.Remove(platform);
            await _context.SaveChangesAsync();
            Results.Ok();
        }
    }
}
