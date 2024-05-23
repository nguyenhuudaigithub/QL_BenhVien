using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Data
{
    //[Table("NguoiDung")]
    public class NguoiDung : IdentityUser
    {
        [MaxLength(13)]
        [Required]
        public string CCCD { get; set; }

        [Required]
        [MaxLength(120)]
        public string HoDem { get; set; }

        [Required]
        [MaxLength(10)]
        public string Ten { get; set; }

        //[Required]
        //[MaxLength(12)]
        //public string SDT { get; set; }

        [Required]
        public DateTime NgaySinh { get; set; }

        [Required]
        public bool GioiTinh { get; set; }

        [Required]
        [MaxLength(5)]
        public string IdPhuong { get; set; }
        [Required]
        [MaxLength(255)]
        public string Duong { get; set; }
    }
}
