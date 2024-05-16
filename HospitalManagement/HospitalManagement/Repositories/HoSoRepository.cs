using AutoMapper;
using HospitalManagement.Data;
using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace HospitalManagement.Repositories
{
    public class HoSoRepository : IHoSoRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _clientFactory;

        public HoSoRepository(DataContext context, IMapper mapper, IHttpClientFactory clientFactory)
        {
            _context = context;
            _mapper = mapper;
            _clientFactory = clientFactory;
        }



        public async Task<HoSoModel> GetHoSoModelAsync(FetchHoSoModel fetchHoSoModel)
        {
            var HoSo = await _context.Hosos!.SingleOrDefaultAsync(b => (b.Ten == fetchHoSoModel.Ten && b.SDT == fetchHoSoModel.SDT) || b.MaHoSo == fetchHoSoModel.MaHoSo);
            if (HoSo != null)
            {
                ChiTietDiaChiModel chiTietDiaChiModel = await GetChiTietDiaChiModelAsync(HoSo.IdPhuong);

                HoSoModel hoSoModel = _mapper.Map<HoSoModel>(HoSo);

                var danToc = await _context.DanTocs!.SingleOrDefaultAsync(b => b.id == HoSo.IdDanToc);
                var ngheNghiep = await _context.NgheNghieps!.SingleOrDefaultAsync(b => b.id == HoSo.IdNgheNghiep);
                var quocTich = await _context.QuocTichs!.SingleOrDefaultAsync(b => b.id == HoSo.IdQuocTich);
                if (danToc != null)
                {
                hoSoModel.TenDanToc = danToc.TenDanToc;

                }
                if (ngheNghiep != null)
                {
                hoSoModel.TenNgheNghiep = ngheNghiep.TenNgheNghiep;

                }
                if (quocTich != null)
                {

                hoSoModel.TenQuocTich = quocTich.TenQuocTich;
                }

                if (chiTietDiaChiModel != null)
                {
                    hoSoModel.IdPhuong = chiTietDiaChiModel.IdPhuong;
                    hoSoModel.TenPhuong = chiTietDiaChiModel.TenPhuong;
                    hoSoModel.IdHuyen = chiTietDiaChiModel.IdHuyen;
                    hoSoModel.TenHuyen = chiTietDiaChiModel.TenHuyen;
                    hoSoModel.IdTinh = chiTietDiaChiModel.IdTinh;
                    hoSoModel.TenTinh = chiTietDiaChiModel.TenTinh;
                }

                return hoSoModel;
            }
            else
            {
                throw new Exception("Không tìm thấy hồ sơ.");
            }
        }

        // Lấy danh sách tỉnh
        public async Task<List<TinhModel>> GetTinhModelListAsync()
        {
            string baseUrl = "https://esgoo.net/api-tinhthanh/1/0.htm";
            var httpClient = _clientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync(baseUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var responseObject = JObject.Parse(jsonResponse);
                var data = responseObject["data"];

                if (data != null)
                {
                    List<TinhModel> tinhModels = new List<TinhModel>();

                    foreach (var item in data)
                    {
                        TinhModel tinhModel = new TinhModel
                        {
                            IdTinh = (string)item["id"],
                            TenTinh = (string)item["name"]
                        };

                        tinhModels.Add(tinhModel);
                    }

                    return tinhModels;
                }
                else
                {
                    throw new Exception("Dữ liệu không hợp lệ.");
                }
            }
            else
            {
                throw new HttpRequestException($"Lỗi danh sách tỉnh");
            }
        }

        // Lấy danh sách huyện
        public async Task<List<HuyenModel>> GetHuyenModelListAsync(string idTinh)
        {
            string baseUrl = "https://esgoo.net/api-tinhthanh/2/" + idTinh + ".htm";
            var httpClient = _clientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync(baseUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var responseObject = JObject.Parse(jsonResponse);
                var data = responseObject["data"];

                if (data != null)
                {
                    List<HuyenModel> huyenModels = new List<HuyenModel>();

                    foreach (var item in data)
                    {
                        HuyenModel huyenModel = new HuyenModel
                        {
                            IdHuyen = (string)item["id"],
                            TenHuyen = (string)item["name"]
                        };

                        huyenModels.Add(huyenModel);
                    }

                    return huyenModels;
                }
                else
                {
                    throw new Exception("Dữ liệu không hợp lệ.");
                }
            }
            else
            {
                throw new HttpRequestException($"Lỗi danh sách huyện");
            }
        }

        // Lấy danh sách phường
        public async Task<List<PhuongModel>> GetPhuongModelListAsync(string idHuyen)
        {
            string baseUrl = "https://esgoo.net/api-tinhthanh/3/" + idHuyen + ".htm";
            var httpClient = _clientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync(baseUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var responseObject = JObject.Parse(jsonResponse);
                var data = responseObject["data"];

                if (data != null)
                {
                    List<PhuongModel> phuongModels = new List<PhuongModel>();

                    foreach (var item in data)
                    {
                        PhuongModel phuongModel = new PhuongModel
                        {
                            IdPhuong = (string)item["id"],
                            TenPhuong = (string)item["name"]
                        };

                        phuongModels.Add(phuongModel);
                    }

                    return phuongModels;
                }
                else
                {
                    throw new Exception("Dữ liệu không hợp lệ.");
                }
            }
            else
            {
                throw new HttpRequestException($"Lỗi danh sách phường");
            }
        }

        // Lấy chi tiết các tỉnh và quận từ idPhuong
        public async Task<ChiTietDiaChiModel> GetChiTietDiaChiModelAsync(string idPhuong)
        {
            string baseUrl = "https://esgoo.net/api-tinhthanh/5/" + idPhuong + ".htm";
            var httpClient = _clientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync(baseUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var responseObject = JObject.Parse(jsonResponse);
                var data = responseObject["data"];

                if (data != null)
                {
                    string name = (string)data["name"];
                    string[] parts = name.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    // Create ChiTietDiaChiModel object
                    ChiTietDiaChiModel chiTietDiaChi = new ChiTietDiaChiModel
                    {
                        IdPhuong = (string)data["phuong"],
                        TenPhuong = parts[0].Trim(),
                        IdHuyen = (string)data["quan"],
                        TenHuyen = parts[1].Trim(),
                        IdTinh = (string)data["tinh"],
                        TenTinh = parts[2].Trim()
                    };

                    return chiTietDiaChi;
                }
                else
                {
                    throw new Exception("Dữ liệu không hợp lệ.");
                }
            }
            else
            {
                throw new HttpRequestException($"Không lấy được chi tiết từ idPhuong");
            }
        }
    }
}
