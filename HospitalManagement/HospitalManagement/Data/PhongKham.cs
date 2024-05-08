using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Data
{
    [Table("PhongPham")]
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
        public DatLich DatLich { get; set; }
        
    }
}
