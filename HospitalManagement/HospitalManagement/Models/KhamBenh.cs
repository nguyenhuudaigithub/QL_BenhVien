using HospitalManagement.Data;

namespace HospitalManagement.Models
{
    public class KhamBenh
    {
        public int Id { get; set; }
        public string MaHoSo { get; set; }
        public int IdPhongKham { get; set; }
        public DateTime ThoiGianHen { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayKham { get; set; }
        public int STT { get; set; }
        public string Mota { get; set; }
        public string ChiTietChuanDoan { get; set; }
        public string LoiDan { get; set; }
        public int IdBacSi { get; set; }

        // Navigation properties
        public HoSo HoSo { get; set; }
        public PhongKham PhongKham { get; set; }
        //public BacSi BacSi { get; set; }
    }
}
