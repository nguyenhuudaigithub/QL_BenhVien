using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class DatLichModel
    {
        [Required]
        public DateTime NgayKham { get; set; }
        public int STT { get; set; }

        [Required]
        [MaxLength(11)]
        public int IdPhong { get; set; }

        [Required]
        public DateTime NgayTao { get; set; }   

        [MaxLength(60)]
        public string QuocTich { get; set; }

        [MaxLength(50)]
        public string DanToc { get; set; }

        [MaxLength(50)]
        public string NgheNghiep { get; set; }

        [MaxLength(10)]
        public string? GioKham { get; set; }
        public string? MoTa { get; set; }
        public string? ChiTietChuanDoan { get; set; }
        public string? LoiDan { get; set; }
    }
}
