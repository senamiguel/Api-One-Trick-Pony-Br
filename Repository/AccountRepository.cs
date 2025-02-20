using Api_One_Trick_Pony_Br.Data;
using Api_One_Trick_Pony_Br.Models;
using Api_One_Trick_Pony_Br.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Api_One_Trick_Pony_Br.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApiContext _context;

        public AccountRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAllAsync()
        {
            return await _context.Account.ToListAsync();
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            return await _context.Account.FindAsync(id);
        }

        public async Task AddAsync(Account account)
        {
            await _context.Account.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account update, int id)
        {
            var account = await _context.Account.FindAsync(id);

            if (account is null)
                Results.BadRequest("Conta não encontrada.");

            account.Username = update.Username;
            account.Password = update.Password;

            await _context.SaveChangesAsync();
            Results.Ok(account);
        }

        public async Task DeleteAsync(int id)
        {
            var platform = await _context.Account.FindAsync(id);

            if (platform is null)
                Results.NotFound();

            _context.Account.Remove(platform);
            await _context.SaveChangesAsync();
            Results.Ok();
        }
    }
}
