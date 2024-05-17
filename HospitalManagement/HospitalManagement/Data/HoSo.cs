using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Data
{
    [Table("HoSo")]
    public class HoSo
    {
        [Key]
        [MaxLength(100)]
        public string MaHoSo { get; set; }

        [MaxLength(13)]
        [Required]
        public string CCCD { get; set; }

        [Required]
        [MaxLength(120)]
        public string HoDem { get; set; }

        [Required]
        [MaxLength(10)]
        public string Ten { get; set; }

        [Required]
        [MaxLength(12)]
        public string SDT { get; set; }

        [Required]
        public DateTime NgaySinh { get; set; }

        [Required]
        [MaxLength(70)]
        public string Email { get; set; }
        [Required]
        public bool GioiTinh { get; set; }

        [Required]
        [MaxLength(5)]
        public string IdPhuong { get; set; }
        [Required]
        [MaxLength(255)]
        public string Duong { get; set; }

        public DateTime? NgayTaoHoSo { get; set; } = DateTime.Now;

        [ForeignKey("QuocTich")]
        public int? IdQuocTich { get; set; }
        public QuocTich QuocTich { get; set; }

        [ForeignKey("NgheNghiep")]
        public int? IdNgheNghiep { get; set; }
        public NgheNghiep NgheNghiep { get; set; }

        [ForeignKey("DanToc")]
        public int? IdDanToc { get; set; }
        public DanToc DanToc { get; set; }

        public ICollection<DatLich> DatLichs { get; set; }
    }
}
