using Api_One_Trick_Pony_Br.Models;

namespace Api_One_Trick_Pony_Br.Services.Interfaces
{
    public interface IPonyService
    {
        Task<List<Pony>> GetAllAsync();
        Task<Pony?> GetByIdAsync(int id);
        Task AddAsync(Pony pony);
        Task UpdateAsync(Pony pony);
        Task DeleteAsync(int id);
    }
}
