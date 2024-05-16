using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HospitalManagement.Data;
using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public class DanTocRepository : IDanTocRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DanTocRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddDanTocAsync(DanTocModel model)
        {
            var newDanToc = _mapper.Map<DanToc>(model);
            _context.DanTocs!.Add(newDanToc);
            await _context.SaveChangesAsync();
            return newDanToc.id;
        }

        public async Task DeleteDanTocAsync(int id)
        {
            var deleteDanToc = _context.DanTocs!.SingleOrDefault(b => b.id == id);
            if (deleteDanToc != null)
            {
                _context.DanTocs!.Remove(deleteDanToc);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DanTocModel>> GetAllDanTocsAsync()
        {
            var DanTocs = await _context.DanTocs!.ToListAsync();
            return _mapper.Map<List<DanTocModel>>(DanTocs);
        }

        public async Task<DanTocModel> GetDanTocAsync(int id)
        {
            var DanToc = await _context.DanTocs!.FindAsync(id);
            return _mapper.Map<DanTocModel>(DanToc);
        }

        public async Task UpdateDanTocAsync(int id, DanTocModel model)
        {
            var getId = _context.DanTocs!.SingleOrDefault(b => b.id == id);
            if (getId != null && getId.id == model.id)
            {
                getId.TenDanToc = model.TenDanToc;
                _context.DanTocs!.Update(getId);
                await _context.SaveChangesAsync();
            }
        }
    }
}
