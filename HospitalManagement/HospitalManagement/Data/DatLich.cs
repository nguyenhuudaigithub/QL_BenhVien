using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Data
{
    [Table("DatLich")]
    public class DatLich
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public DateTime NgayKham { get; set; }

        [ForeignKey("PhongKham")]
        [Required, MaxLength(11)]
        public int IdPhong { get; set; }

        [Required]
        public DateTime NgayTao { get; set; }

        //Có thể nhập trống
        [MaxLength(60)]
        public string? QuocTich { get; set; }
        [MaxLength(50)]
        public string? DanToc { get; set; }
        [MaxLength(50)]
        public string? NgheNghiep { get; set; }
        [MaxLength(10)]
        public string? GioKham { get; set; }

        // Tham chiếu tới các bảng
        [ForeignKey("HoSo")]
        public string MaHoSo { get; set; }
        public HoSo HoSo { get; set; }
        public PhongKham PhongKham { get; set; }
    }
}
