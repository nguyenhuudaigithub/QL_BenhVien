using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Data
{
    [Table("PhongKham")]
    public class PhongKham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(11)]
        public int id { get; set; }
        [Required]
        public int SoLuongToiDa { get; set; }
        [Required]
        public string TenPhongKham { get; set; }

        //Tham chiếu tới bảng DatLich
        public ICollection<DatLich> DatLichs { get; set; }

    }
}
