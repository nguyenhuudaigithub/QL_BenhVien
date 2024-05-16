using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HospitalManagement.Data;
using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public class QuocTichRepository : IQuocTichRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public QuocTichRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddQuocTichAsync(QuocTichModel model)
        {
            var newQuocTich = _mapper.Map<QuocTich>(model);
            _context.QuocTichs!.Add(newQuocTich);
            await _context.SaveChangesAsync();

            return newQuocTich.id;
        }

        public async Task DeleteQuocTichAsync(int id)
        {
            var deleteQuocTich = _context.QuocTichs!.SingleOrDefault(b => b.id == id);
            if (deleteQuocTich != null)
            {
                _context.QuocTichs!.Remove(deleteQuocTich);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<QuocTichModel>> GetAllQuocTichsAsync()
        {
            var QuocTichs = await _context.QuocTichs!.ToListAsync();
            return _mapper.Map<List<QuocTichModel>>(QuocTichs);
        }

        public async Task<QuocTichModel> GetQuocTichAsync(int id)
        {
            var QuocTich = await _context.QuocTichs!.FindAsync(id);
            return _mapper.Map<QuocTichModel>(QuocTich);
        }

        public async Task UpdateQuocTichAsync(int id, QuocTichModel model)
        {
            var getId = _context.QuocTichs!.SingleOrDefault(b => b.id == id);
            if (getId != null && getId.id == model.id)
            {
                getId.TenQuocTich = model.TenQuocTich;
                getId.TenVietTat = model.TenVietTat;
                _context.QuocTichs!.Update(getId);

                await _context.SaveChangesAsync();
            }
        }
    }
}
