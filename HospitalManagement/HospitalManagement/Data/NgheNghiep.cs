using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Data
{
    [Table("NgheNghiep")]
    public class NgheNghiep
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(11)]
        public int id {  get; set; }

        [Required]
        public string TenNgheNghiep { get; set; }

        //Tham chiếu tới bảng DatLich
        //public DatLich DatLich { get; set; }
    }
}
