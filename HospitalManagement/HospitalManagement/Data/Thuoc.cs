using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Data
{
    [Table("Thuoc")]
    public class Thuoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(11)]
        public int id { get; set; }
        [Required]
        public string? TenThuoc { get; set; }
        public decimal GiaTien { get; set; }
        public int SoLuongConLai { get; set; }
    }
}
