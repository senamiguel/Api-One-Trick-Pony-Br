using Api_One_Trick_Pony_Br.Models; 

namespace Api_One_Trick_Pony_Br.Repository.Interfaces
{
    public interface IPonyRepository
    {
        Task<List<Pony>> GetAllAsync();
        Task<Pony?> GetByIdAsync(int id);
        Task AddAsync(Pony pony);
        Task UpdateAsync(Pony pony);
        Task DeleteAsync(int id);
    }
}
