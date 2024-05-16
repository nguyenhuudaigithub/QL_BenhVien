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

        //Address
        //[Required]
        //[MaxLength(5)]
        //public int IdTinh { get; set; }
        //[Required]
        //[MaxLength(5)]
        //public int IdHuyen { get; set; }
        [Required]
        [MaxLength(5)]
        public string IdPhuong { get; set; }
        [Required]
        [MaxLength(255)]
        public string SoNha { get; set; }

        public DateTime? NgayTaoHoSo { get; set; } = DateTime.Now;

        public ICollection<DatLich> DatLichs { get; set; }
    }
}
