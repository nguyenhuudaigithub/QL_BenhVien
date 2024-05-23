using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Data
{
    [Table("DonThuoc")]
    public class DonThuoc
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("idDatLich")]
        public int? idDatLich { get; set; }

        [ForeignKey("idBacSi")]
        public string? idBacSi { get; set; }
        public DatLich DatLich { get; set; }
        public ICollection<DonThuocChiTiet> DonThuocChiTiets { get; set; }
    }
}
