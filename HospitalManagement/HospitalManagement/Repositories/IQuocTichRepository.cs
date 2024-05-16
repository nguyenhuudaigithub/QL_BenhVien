using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public interface IQuocTichRepository
    {
        public Task<List<QuocTichModel>> GetAllQuocTichsAsync();
        public Task<QuocTichModel> GetQuocTichAsync(int id);
        public Task<int> AddQuocTichAsync(QuocTichModel model);
        public Task UpdateQuocTichAsync(int id, QuocTichModel model);
        public Task DeleteQuocTichAsync(int id);
    }
}
