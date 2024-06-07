using AutoMapper;
using HospitalManagement.Data;
using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repositories
{
    public class DatLichRepository : IDatLichRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DatLichRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DatLichModel> GetDatLichAsync(int id)
        {
            var DatLich = await _context.DatLichs.FindAsync(id);
            return _mapper.Map<DatLichModel>(DatLich);
        }

        public async Task<List<DatLichModel>> GetDatLichByEmailAndCCCDAsync(string email, string CCCD)
        {
            var HoSo = await _context.Hosos!.SingleOrDefaultAsync(b => (b.Email == email && b.CCCD == CCCD));

            if (HoSo == null)
            {
                return null;
            }
            else
            {
                var QuocTich = await _context.QuocTichs!.SingleOrDefaultAsync(b => (b.id == HoSo.IdQuocTich));
                var DanToc = await _context.DanTocs!.SingleOrDefaultAsync(b => (b.id == HoSo.IdDanToc));
                var NgheNghiep = await _context.NgheNghieps!.SingleOrDefaultAsync(b => (b.id == HoSo.IdNgheNghiep));

                var datLichEntities = await _context.DatLichs!.Where(d => d.MaHoSo == HoSo.MaHoSo).ToListAsync();

                var datLichModels = new List<DatLichModel>();

                foreach (var datLichEntity in datLichEntities)
                {
                    var datLichModel = new DatLichModel
                    {
                        id = datLichEntity.id,
                        STT = datLichEntity.STT,
                        NgayKham = datLichEntity.NgayKham,
                        NgayTao = datLichEntity.NgayTao,
                        GioKham = datLichEntity.GioKham,
                        MoTa = datLichEntity.MoTa,
                        ChiTietChuanDoan = datLichEntity.ChiTietChuanDoan,
                        LoiDan = datLichEntity.LoiDan,
                        QuocTich = QuocTich.TenQuocTich,
                        DanToc = DanToc.TenDanToc,
                        NgheNghiep = NgheNghiep.TenNgheNghiep
                    };

                    datLichModels.Add(datLichModel);
                }

                return datLichModels;
            }
        }

        public async Task UpdateDatLichAsync(int id, DatLichModel model)
        {
            var getId = _context.DatLichs!.SingleOrDefault(b => b.id == id);
            if (getId != null && getId.id == model.id)
            {
                getId.MoTa = model.MoTa;
                getId.ChiTietChuanDoan = model.ChiTietChuanDoan;
                getId.LoiDan = model.LoiDan;
                _context.DatLichs!.Update(getId);
                await _context.SaveChangesAsync();
            }
        }

    }
}
