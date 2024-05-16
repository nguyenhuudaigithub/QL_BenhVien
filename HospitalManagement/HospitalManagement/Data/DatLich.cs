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
        public int STT { get; set; }
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

        [ForeignKey("DanToc")]
        [MaxLength(11)]
        public int? IdDanToc { get; set; }

        [ForeignKey("NgheNghiep")]
        [MaxLength(11)]
        public int? IdNgheNghiep { get; set; }

        [MaxLength(10)]
        public string? GioKham { get; set; }

        // Tham chiếu tới HoSo
        public string MaHoSo { get; set; }

        public HoSo HoSo { get; set; }

        public PhongKham PhongKham { get; set; }
        public DanToc DanToc { get; set; }
        public NgheNghiep NgheNghiep { get; set; }
    }
}
