using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HospitalManagement.Data;
using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public class NgheNghiepRepository : INgheNghiepRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public NgheNghiepRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddNgheNghiepAsync(NgheNghiepModel model)
        {
            var newNgheNghiep = _mapper.Map<NgheNghiep>(model);
            _context.NgheNghieps!.Add(newNgheNghiep);
            await _context.SaveChangesAsync();
            return newNgheNghiep.id;
        }

        public async Task DeleteNgheNghiepAsync(int id)
        {
            var deleteNgheNghiep = _context.NgheNghieps!.SingleOrDefault(b => b.id == id);
            if (deleteNgheNghiep != null)
            {
                _context.NgheNghieps!.Remove(deleteNgheNghiep);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<NgheNghiepModel>> GetAllNgheNghiepsAsync()
        {
            var NgheNghieps = await _context.NgheNghieps!.ToListAsync();
            return _mapper.Map<List<NgheNghiepModel>>(NgheNghieps);
        }

        public async Task<NgheNghiepModel> GetNgheNghiepAsync(int id)
        {
            var NgheNghiep = await _context.NgheNghieps!.FindAsync(id);
            return _mapper.Map<NgheNghiepModel>(NgheNghiep);
        }

        public async Task UpdateNgheNghiepAsync(int id, NgheNghiepModel model)
        {
            var getId = _context.NgheNghieps!.SingleOrDefault(b => b.id == id);
            if (getId != null && getId.id == model.id)
            {
                getId.TenNgheNghiep = model.TenNgheNghiep;
                _context.NgheNghieps!.Update(getId);
                await _context.SaveChangesAsync();
            }
        }
    }
}
