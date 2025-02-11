using Api_One_Trick_Pony_Br.Models;

namespace Api_One_Trick_Pony_Br.Repository.Interfaces
{
    public interface IPlatformRepository
    {
        Task<List<Platform>> GetAllAsync();
        Task<Platform?> GetByIdAsync(int id);
        Task AddAsync(Platform platform);
        Task UpdateAsync(Platform platform);
        Task DeleteAsync(int id);
    }
}
