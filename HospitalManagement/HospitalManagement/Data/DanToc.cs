using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Data
{
    [Table("DanToc")]
    public class DanToc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(11)]
        public int id { get; set; }

        [Required]
        public string TenDanToc { get; set; }

        //Tham chiếu tới bảng DatLich
        public DatLich DatLich { get; set; }
    }
}
