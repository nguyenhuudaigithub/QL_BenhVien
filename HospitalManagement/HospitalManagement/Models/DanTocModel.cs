using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class DanTocModel
    {
        public int id { get; set; }
        [Required]
        public string TenDanToc { get; set; }
    }
}
