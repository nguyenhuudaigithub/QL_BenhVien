using HospitalManagement.Data;
using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public interface IDatLichRepository
    {
        public Task<DatLichModel>GetDatLichAsync(int id);
        public Task UpdateDatLichAsync(int id, DatLichModel datLich);

    }
}
