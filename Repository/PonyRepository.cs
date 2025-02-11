using Api_One_Trick_Pony_Br.Data;
using Api_One_Trick_Pony_Br.Models;
using Api_One_Trick_Pony_Br.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

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

        public async Task UpdateAsync(Pony pony)
        {
            _context.Pony.Update(pony);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pony = await GetByIdAsync(id);
            if (pony == null)
            {
                Results.NotFound();
            }
            _context.Pony.Remove(pony);
            await _context.SaveChangesAsync();
        }
    }
}
