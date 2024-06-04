using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public interface IDatLichRepository
    {
        public Task<DatLichModel> GetDatLichAsync(int id);
        public Task<List<DatLichModel>> GetDatLichByEmailAndCCCDAsync(string email, string CCCD);
        public Task UpdateDatLichAsync(int id, DatLichModel datLich);

    }
}
