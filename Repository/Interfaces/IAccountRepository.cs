using Api_One_Trick_Pony_Br.Models;

namespace Api_One_Trick_Pony_Br.Repository.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAsync();
        Task<Account?> GetByIdAsync(int id);
        Task AddAsync(Account account);
        Task UpdateAsync(Account account, int id);
        Task DeleteAsync(int id);
    }
}
