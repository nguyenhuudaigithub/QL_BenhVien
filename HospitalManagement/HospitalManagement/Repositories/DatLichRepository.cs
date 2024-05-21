﻿using AutoMapper;
using HospitalManagement.Data;
using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repositories
{
    public class DatLichRepository : IDatLichRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DatLichRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DatLichModel> GetDatLichAsync(int id)
        {
            var DatLich = await _context.DatLichs.FindAsync(id);
            return _mapper.Map<DatLichModel>(DatLich);
        }
        public async Task UpdateDatLichAsync(int id, DatLichModel model)
        {
            var getId = _context.DatLichs!.SingleOrDefault(b => b.id == id);
            if (getId != null && getId.id == model.id)
            {
                getId.MoTa = model.MoTa;
                getId.ChiTietChuanDoan = model.ChiTietChuanDoan;
                getId.LoiDan = model.LoiDan;
                _context.DatLichs!.Update(getId);
                await _context.SaveChangesAsync();
            }
        }
    }
}
