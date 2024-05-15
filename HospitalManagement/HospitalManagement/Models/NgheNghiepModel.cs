using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class NgheNghiepModel
    {
        public int id { get; set; }
        [Required]
        public string TenNgheNghiep { get; set; }
    }
}
