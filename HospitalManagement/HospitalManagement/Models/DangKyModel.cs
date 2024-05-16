namespace HospitalManagement.Models
{

    public class DangKyModel
    {
        public string MaHoSo { get; set; }

        public string CCCD { get; set; }

        public string HoDem { get; set; }

        public string Ten { get; set; }

        public string SDT { get; set; }

        public DateTime NgaySinh { get; set; }

        public string Email { get; set; }
        public bool GioiTinh { get; set; }

        public string IdPhuong { get; set; }
        public string Duong { get; set; }

        public DateTime? NgayTaoHoSo { get; set; }

        public DateTime NgayKham { get; set; }

        public int IdPhong { get; set; }

        public DateTime NgayTao { get; set; }

        public int IdQuocTich { get; set; }
        public int IdDanToc { get; set; }
        public int IdNgheNghiep { get; set; }
        public string? GioKham { get; set; }

    }



}
