using AutoMapper;
using HospitalManagement.Data;
using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repositories
{
    public class HoSoRepository: IHoSoRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public HoSoRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        

        public async Task<HoSoModel> GetHoSoModelAsync(FetchHoSoModel fetchHoSoModel)
        {
            var HoSo = await _context.Hosos!.SingleOrDefaultAsync(b => b.Ten == fetchHoSoModel.Ten && b.SDT == fetchHoSoModel.SDT);
            return _mapper.Map<HoSoModel>(HoSo);
        }
    }
}
