using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Data
{
    [Table("QuocTich")]
    public class QuocTich
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(11)]
        public int id { get; set; }

        [Required]
        public string TenQuocTich { get; set; }
        public string TenVietTat { get; set; }
    }
}
