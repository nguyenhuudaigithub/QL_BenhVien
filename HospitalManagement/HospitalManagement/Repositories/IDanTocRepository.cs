using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public interface IDanTocRepository
    {
        public Task<List<DanTocModel>> GetAllDanTocsAsync();
        public Task<DanTocModel> GetDanTocAsync(int id);
        public Task<int> AddDanTocAsync(DanTocModel model);
        public Task UpdateDanTocAsync(int id, DanTocModel model);
        public Task DeleteDanTocAsync(int id);
    }
}
