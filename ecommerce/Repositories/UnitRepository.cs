using Microsoft.EntityFrameworkCore;
using ecommerce.Database;
using ecommerce.Models;

namespace ecommerce.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly AppDbContext _context;

        public UnitRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Unit>> GetAllAsync()
        {
            return await _context.Units
                .OrderByDescending(u => u.Id)
                .ToListAsync();
        }

        public async Task<Unit> GetByIdAsync(int id)
        {
            return await _context.Units.FindAsync(id);
        }

        public async Task AddAsync(Unit unit)
        {
            await _context.Units.AddAsync(unit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Unit unit)
        {
            _context.Units.Update(unit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var unit = await _context.Units.FindAsync(id);
            if (unit != null)
            {
                _context.Units.Remove(unit);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> UnitExistsAsync(int id)
        {
            return await _context.Units.AnyAsync(e => e.Id == id);
        }
    }
}