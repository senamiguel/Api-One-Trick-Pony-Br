using Api_One_Trick_Pony_Br.Models;

namespace Api_One_Trick_Pony_Br.Repository.Interfaces
{
    public interface ISocialMediaRepository
    {
        Task<List<SocialMedia>> GetAllAsync();
        Task<SocialMedia?> GetByIdAsync(int id);
        Task AddAsync(SocialMedia socialMedia);
        Task UpdateAsync(SocialMedia socialMedia, int id);
        Task DeleteAsync(int id);
    }
}
