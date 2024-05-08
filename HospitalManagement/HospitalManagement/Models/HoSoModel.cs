using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Models
{
    public class HoSoModel
    {
        public string MaHoSo { get; set; }

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

        //[Required]
        //[MaxLength(5)]
        //public int IdTinh { get; set; }

        //[Required]
        //[MaxLength(5)]
        //public int IdHuyen { get; set; }

        [Required]
        [MaxLength(5)]
        public int IdXa { get; set; }

        [Required]
        [MaxLength(255)]
        public string SoNha { get; set; }

        //public ICollection<DatLichModel> DatLichs { get; set; }
    }
}
