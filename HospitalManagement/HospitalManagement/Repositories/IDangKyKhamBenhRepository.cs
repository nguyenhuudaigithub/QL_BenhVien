using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public interface IDangKyKhamBenhRepository
    {
        public Task<int> AddDangKyAsync(DangKyModel dangKyModel);
    }
}
