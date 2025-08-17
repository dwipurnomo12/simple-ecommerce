using ecommerce.Models;

namespace ecommerce.Repositories
{
    public interface IUnitRepository
    {
        Task<IEnumerable<Unit>> GetAllAsync();
        Task<Unit> GetByIdAsync(int id);
        Task AddAsync(Unit unit);
        Task UpdateAsync(Unit unit);
        Task DeleteAsync(int id);
    }
}