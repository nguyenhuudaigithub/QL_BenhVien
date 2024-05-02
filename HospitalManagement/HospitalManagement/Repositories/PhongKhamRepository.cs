using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HospitalManagement.Data;
using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public class PhongKhamRepository : IPhongKhamRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PhongKhamRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddPhongKhamAsync(PhongKhamModel model)
        {
            var newPhongKham = _mapper.Map<PhongKham>(model);
            _context.PhongKhams!.Add(newPhongKham);
            await _context.SaveChangesAsync();

            return newPhongKham.id;
        }

        public async Task DeletePhongKhamAsync(int id)
        {
            var deletePhongKham = _context.PhongKhams!.SingleOrDefault(b => b.id == id);
            if (deletePhongKham != null)
            {
                _context.PhongKhams!.Remove(deletePhongKham);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<PhongKhamModel>> GetAllPhongKhamsAsync()
        {
            var PhongKhams = await _context.PhongKhams!.ToListAsync();
            return _mapper.Map<List<PhongKhamModel>>(PhongKhams);
        }

        public async Task<PhongKhamModel> GetPhongKhamAsync(int id)
        {
            var PhongKham = await _context.PhongKhams!.FindAsync(id);
            return _mapper.Map<PhongKhamModel>(PhongKham);
        }

        public async Task UpdatePhongKhamAsync(int id, PhongKhamModel model)
        {
            var getId = _context.PhongKhams!.SingleOrDefault(b => b.id == id);





            if (getId != null && getId.id == model.id)
            {
                //var updatePhongKham = _mapper.Map<PhongKham>(getId);
                getId.TenPhongKham = model.TenPhongKham;
                _context.PhongKhams!.Update(getId);

                await _context.SaveChangesAsync();

            }
        }
    }
}
