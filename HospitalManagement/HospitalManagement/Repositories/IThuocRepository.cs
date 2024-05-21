using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public interface IThuocRepository
    {
        public Task<List<ThuocModel>> GetAllThuocsAsync();
        public Task<ThuocModel> GetThuocAsync(int id);
        public Task<int> AddThuocAsync(ThuocModel model);
        public Task UpdateThuocAsync(int id, ThuocModel model);
        public Task DeleteThuocAsync(int id);
    }
}
