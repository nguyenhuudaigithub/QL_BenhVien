using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class PhongKhamModel
    {
        public int id { get; set; }
        [Required]
        public string TenPhongKham { get; set; }    
        //public DatLichModel DatLich { get; set; }
    }
}
