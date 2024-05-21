using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class ThuocModel
    {
        public int id { get; set; }
        [Required]
        public string TenThuoc { get; set; }
        public decimal GiaTien { get; set; }
        public int SoLuongConLai { get; set; }
    }
}
