using Api_One_Trick_Pony_Br.Data;
using Api_One_Trick_Pony_Br.Models;
using Api_One_Trick_Pony_Br.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Api_One_Trick_Pony_Br.Repository
{
    public class PonyRepository : IPonyRepository
    {
        private readonly ApiContext _context;

        public PonyRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<Pony>> GetAllAsync()
        {
            return await _context.Pony.ToListAsync();
        }

        public async Task<Pony?> GetByIdAsync(int id)
        {
            return await _context.Pony.FindAsync(id);
        }

        public async Task AddAsync(Pony pony)
        {
            await _context.Pony.AddAsync(pony);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pony update, int id)
        {
            var pony = await _context.Pony.FindAsync(id);

            if (pony is null)
                Results.BadRequest("Pony não encontrada.");

            pony.Bio = update.Bio;
            pony.IconId = update.IconId;
            pony.Karma = update.Karma;
            pony.Champion = update.Champion;
            pony.Rank = update.Rank;

            await _context.SaveChangesAsync();
            Results.Ok(pony);
        }

        public async Task DeleteAsync(int id)
        {
            var pony = await _context.Pony.FindAsync(id);
            if (pony is null)
                Results.NotFound();

            _context.Pony.Remove(pony);
            await _context.SaveChangesAsync();
            Results.Ok();
        }
    }
}
