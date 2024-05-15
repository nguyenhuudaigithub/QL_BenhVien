using HospitalManagement.Data;
using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repositories
{
    public class KhamBenhRepository : IKhamBenhRepository<KhamBenh>
    {
        private readonly DataContext _context;

        public KhamBenhRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KhamBenh>> GetAllAsync()
        {
            return await _context.KhamBenhs.ToListAsync();
        }

        public async Task<KhamBenh> GetByIdAsync(int id)
        {
            return await _context.KhamBenhs.FindAsync(id);
        }

        public async Task AddAsync(KhamBenh entity)
        {
            await _context.KhamBenhs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(KhamBenh entity)
        {
            _context.KhamBenhs.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.KhamBenhs.FindAsync(id);
            if (entity != null)
            {
                _context.KhamBenhs.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.KhamBenhs.AnyAsync(e => e.Id == id);
        }
    }
}
