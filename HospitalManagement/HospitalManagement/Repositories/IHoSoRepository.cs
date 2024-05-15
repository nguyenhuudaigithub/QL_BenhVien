using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public interface IHoSoRepository
    {
        public Task<HoSoModel> GetHoSoModelAsync(FetchHoSoModel fetchHoSoModel);

        public Task<List<TinhModel>> GetTinhModelListAsync();

        public Task<List<HuyenModel>> GetHuyenModelListAsync(string idTinh);

        public Task<List<PhuongModel>> GetPhuongModelListAsync(string idHuyen);

        public Task<ChiTietDiaChiModel> GetChiTietDiaChiModelAsync(string idPhuong);
    }
}
