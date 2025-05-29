using AutoMapper;
using CashFlowPortal.Applicacion.DTOs;
using CashFlowPortal.Applicacion.Interfaces;
using CashFlowPortal.Domain.Entities;
using CashFlowPortal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace CashFlowPortal.Applicacion.Services
{
    public class TipoGastoService : ITipoGastoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TipoGastoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TipoGastoDto>> GetAllAsync()
        {
            var tipos = await _context.TiposGasto.ToListAsync();
            return _mapper.Map<IEnumerable<TipoGastoDto>>(tipos);
        }

        public async Task<TipoGastoDto?> GetByIdAsync(Guid id)
        {
            var tipo = await _context.TiposGasto.FindAsync(id);
            return tipo == null ? null : _mapper.Map<TipoGastoDto>(tipo);
        }

        public async Task<bool> CreateAsync(TipoGastoDto dto)
        {
            var tipo = _mapper.Map<TipoGasto>(dto);
            tipo.Id = Guid.NewGuid(); // o manejo automático
            tipo.Codigo = await ObtenerSiguienteCodigoAsync();

            _context.TiposGasto.Add(tipo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(TipoGastoDto dto)
        {
            var tipo = await _context.TiposGasto.FindAsync(dto.Id);
            if (tipo == null) return false;

            tipo.Nombre = dto.Nombre;
            tipo.Descripcion = dto.Descripcion;

            _context.TiposGasto.Update(tipo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var tipo = await _context.TiposGasto.FindAsync(id);
            if (tipo == null) return false;

            _context.TiposGasto.Remove(tipo);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<int> ObtenerSiguienteCodigoAsync()
        {
            var ultimo = await _context.TiposGasto.OrderByDescending(t => t.Codigo).FirstOrDefaultAsync();
            return (ultimo?.Codigo ?? 0) + 1;
        }
    }
}
