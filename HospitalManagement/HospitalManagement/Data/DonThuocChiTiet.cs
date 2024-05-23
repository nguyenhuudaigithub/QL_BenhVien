using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Data
{
    public class DonThuocChiTiet
    {
        public int Id { get; set; }
        [ForeignKey("Thuoc")]
        public int IdThuoc { get; set; }
        [ForeignKey("DonThuoc")]
        public int IdDonThuoc { get; set; }
        public int SoLuong { get; set; }
        public string LieuDung { get; set; }

        public Thuoc Thuoc { get; set; }
        public DonThuoc DonThuoc { get; set; }
    }
}
