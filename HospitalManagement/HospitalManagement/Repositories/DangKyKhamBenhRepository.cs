using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HospitalManagement.Data;
using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public class DangKyKhamBenhRepository : IDangKyKhamBenhRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DangKyKhamBenhRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddDangKyAsync(DangKyModel dangKyModel)
        {

            var existingHoSo = await _context.Hosos.FindAsync(dangKyModel.MaHoSo);

            var checkNumberExisting = await _context.Hosos!.SingleOrDefaultAsync(b => b.SDT == dangKyModel.SDT);

            if (checkNumberExisting != null)
            {
                return 0;
            }

            if (existingHoSo == null)
            {
                
                DateTime now = DateTime.Now;
                int year = now.Year;
                int month = now.Month;

                // Kiểm tra xem đã có dữ liệu cho tháng trước đó chưa
                var lastMonthCount = _context.Hosos
                    .Where(h => h.NgayTaoHoSo.HasValue && h.NgayTaoHoSo.Value.Year == year && h.NgayTaoHoSo.Value.Month == month - 1)
                    .Count();

                // Lấy số lượng bản ghi hồ sơ cho tháng hiện tại
                int count = _context.Hosos
                    .Where(h => h.NgayTaoHoSo.HasValue && h.NgayTaoHoSo.Value.Year == year && h.NgayTaoHoSo.Value.Month == month)
                    .Count() + 1;

                if (month == 1)
                {
                    // Nếu là tháng đầu tiên trong năm, kiểm tra số lượng bản ghi của tháng cuối năm trước đó
                    int lastYear = year - 1;
                    var lastYearCount = _context.Hosos
                        .Where(h => h.NgayTaoHoSo.HasValue && h.NgayTaoHoSo.Value.Year == lastYear && h.NgayTaoHoSo.Value.Month == 12)
                        .Count();

                    // Sử dụng tổng số lượng hồ sơ của tháng cuối năm trước đó và của tháng hiện tại
                    count = lastYearCount + count;
                }

                var maHoSoMoi = "CH" + year.ToString().Substring(2) + month.ToString("D2") + count;

                //var newHoSo = _mapper.Map<HoSo>(dangKyModel);

                var newHoSo = new HoSo
                {
                    CCCD = dangKyModel.CCCD,
                    HoDem = dangKyModel.HoDem,
                    Ten = dangKyModel.Ten,
                    SDT = dangKyModel.SDT,
                    NgaySinh = dangKyModel.NgaySinh,
                    Email = dangKyModel.Email,
                    GioiTinh = dangKyModel.GioiTinh,
                    IdTinh = dangKyModel.IdTinh,
                    IdHuyen = dangKyModel.IdHuyen,
                    IdXa = dangKyModel.IdXa,
                    SoNha = dangKyModel.SoNha,
                };


                newHoSo.MaHoSo = maHoSoMoi;

                await _context.Hosos!.AddAsync(newHoSo);
                await _context.SaveChangesAsync();

                existingHoSo = await _context.Hosos.FindAsync(maHoSoMoi);
            } 

            var convertHoSoModel =  _mapper.Map<HoSoModel>(existingHoSo);

            var existingPhongKham = await _context.PhongKhams.FindAsync(dangKyModel.IdPhong);

            if (existingPhongKham != null)
            {
                return 0;
            }

            var datLichNew = new DatLich
            {
                // Gán các giá trị từ dangKyModel cho datLichNew
                NgayKham = dangKyModel.NgayKham,
                IdPhong = dangKyModel.IdPhong,
                NgayTao = DateTime.Now, // Gán ngày tạo mới cho ngày tạo
                QuocTich = dangKyModel.QuocTich,
                IdDanToc = dangKyModel.IdDanToc,
                IdNgheNghiep = dangKyModel.IdNgheNghiep,
                GioKham = dangKyModel.GioKham,

                // Gán MaHoSo từ existingHoSo
                MaHoSo = existingHoSo.MaHoSo
            };

            //var datLichNew = _mapper.Map<DatLich>(dangKyModel);
            //datLichNew.MaHoSo = convertHoSoModel.MaHoSo;

            await _context.DatLichs!.AddAsync(datLichNew);
            await _context.SaveChangesAsync();

            return datLichNew.id;
        }
    }
}
