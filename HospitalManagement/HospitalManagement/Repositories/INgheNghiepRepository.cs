using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public interface INgheNghiepRepository
    {
        public Task<List<NgheNghiepModel>> GetAllNgheNghiepsAsync();
        public Task<NgheNghiepModel> GetNgheNghiepAsync(int id);
        public Task<int> AddNgheNghiepAsync(NgheNghiepModel model);
        public Task UpdateNgheNghiepAsync(int id, NgheNghiepModel model);
        public Task DeleteNgheNghiepAsync(int id);
    }
}
