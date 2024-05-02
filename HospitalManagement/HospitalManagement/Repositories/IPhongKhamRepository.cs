using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public interface IPhongKhamRepository
    {
        public Task<List<PhongKhamModel>> GetAllPhongKhamsAsync();
        public Task<PhongKhamModel> GetPhongKhamAsync(int id);
        public Task<int> AddPhongKhamAsync(PhongKhamModel model);
        public Task UpdatePhongKhamAsync(int id, PhongKhamModel model);
        public Task DeletePhongKhamAsync(int id);
    }
}
