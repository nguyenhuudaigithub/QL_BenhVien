using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public interface IHoSoRepository
    {
        public Task<HoSoModel> GetHoSoModelAsync(FetchHoSoModel fetchHoSoModel);
    }
}
