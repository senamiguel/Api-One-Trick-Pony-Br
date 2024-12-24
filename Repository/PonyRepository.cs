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

        public async Task AddAsync(Pony poney)
        {
            await _context.Pony.AddAsync(poney);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pony poney)
        {
            _context.Pony.Update(poney);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var poney = await GetByIdAsync(id);
            if (poney != null)
            {
                _context.Pony.Remove(poney);
                await _context.SaveChangesAsync();
            }
        }
    }
}
