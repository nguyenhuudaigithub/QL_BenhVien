using AutoMapper;
using HospitalManagement.Data;
using HospitalManagement.Models;
namespace HospitalManagement.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<HoSo, HoSoModel>().ReverseMap();
            CreateMap<DatLich, DatLichModel>().ReverseMap();
            CreateMap<PhongKham, PhongKhamModel>().ReverseMap();
        }
    }
}
