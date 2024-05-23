using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Data
{
    [Table("DatLich")]
    public class DatLich
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(100)]
        public int id { get; set; }
        public int STT { get; set; }
        [Required]
        public DateTime NgayKham { get; set; }

        [ForeignKey("PhongKham")]
        [Required, MaxLength(11)]
        public int IdPhong { get; set; }

        [Required]
        public DateTime NgayTao { get; set; }
        
        [MaxLength(10)]
        public string? GioKham { get; set; }
        public string? MoTa { get; set; }
        public string? ChiTietChuanDoan { get; set; }
        public string? LoiDan { get; set; }

        // Tham chiếu tới HoSo
        [ForeignKey("HoSo")]
        [Required]
        public string MaHoSo { get; set; }
        public HoSo HoSo { get; set; }

        public PhongKham PhongKham { get; set; }
        public DonThuoc DonThuoc { get; set; }
    }
}
