using AutoMapper;
using HospitalManagement.Data;

namespace HospitalManagement.Repositories
{
    public class NguoiDungRepository : INguoiDungRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public NguoiDungRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
