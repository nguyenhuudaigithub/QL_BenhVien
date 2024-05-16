using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class QuocTichModel
    {
        public int id { get; set; }
        [Required]
        public string TenQuocTich { get; set; }
        public string TenVietTat { get; set; }
    }
}
