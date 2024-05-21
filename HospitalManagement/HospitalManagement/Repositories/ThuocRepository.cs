using AutoMapper;
using HospitalManagement.Data;
using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repositories
{
    public class ThuocRepository : IThuocRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ThuocRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddThuocAsync(ThuocModel model)
        {
            var newThuoc = _mapper.Map<Thuoc>(model);
            _context.Thuocs!.Add(newThuoc);      
            await _context.SaveChangesAsync();
            return newThuoc.id;
        }


        public async Task DeleteThuocAsync(int id)
        {
            var deleteThuoc = _context.Thuocs!.SingleOrDefault(b => b.id == id);
            if (deleteThuoc != null)
            {
                _context.Thuocs!.Remove(deleteThuoc);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ThuocModel>> GetAllThuocsAsync()
        {
            var AllThuoc = await _context.Thuocs!.ToListAsync();
            return _mapper.Map<List<ThuocModel>>(AllThuoc);
        }

        public async Task<ThuocModel> GetThuocAsync(int id)
        {
            var Thuoc = await _context.Thuocs!.FindAsync(id);
            return _mapper.Map<ThuocModel>(Thuoc);
        }

        public async Task UpdateThuocAsync(int id, ThuocModel model)
        {
            var getId = _context.Thuocs!.SingleOrDefault(b => b.id == id);
            if (getId != null && getId.id == model.id)
            {
                getId.TenThuoc = model.TenThuoc;
                getId.SoLuongConLai = model.SoLuongConLai;
                _context.Thuocs!.Update(getId);
                await _context.SaveChangesAsync();
            }
        }
    }
}
