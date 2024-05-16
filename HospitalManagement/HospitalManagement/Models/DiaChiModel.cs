namespace HospitalManagement.Models
{


    public class DiaChiModel
    {
        public int Error { get; set; }
        public string ErrorText { get; set; }
        public DiaChiData Data { get; set; }
    }

    public class DiaChiData
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string FullName { get; set; }
        public string FullNameEn { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Tinh { get; set; }
        public string Quan { get; set; }
        public string Phuong { get; set; }
    }

}
