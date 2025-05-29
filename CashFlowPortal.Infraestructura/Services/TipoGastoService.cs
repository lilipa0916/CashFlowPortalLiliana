using AutoMapper;
using CashFlowPortal.Applicacion.DTOs.TipoGasto;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using CashFlowPortal.Applicacion.Interfaces.Repository;
using CashFlowPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Infraestructura.Services
{
    public class TipoGastoService : ITipoGastoService
    {
        private readonly ITipoGastoRepository _repository;
        private readonly IMapper _mapper;

        public TipoGastoService(ITipoGastoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TipoGastoDto> CreateAsync(TipoGastoDto dto)
        {
            var entity = _mapper.Map<TipoGasto>(dto);
            entity.Codigo = await _repository.GenerarCodigoAsync();

            await _repository.AddAsync(entity);

            return _mapper.Map<TipoGastoDto>(entity);
        }
        public async Task CreateAsync(TipoGastoFormDto dto)
        {
            var tipo = _mapper.Map<TipoGasto>(dto);
            await _repository.AddAsync(tipo);
        }

        public async Task<IEnumerable<TipoGastoDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TipoGastoDto>>(entities);
        }

        public async Task<TipoGastoDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TipoGastoDto>(entity);
        }

        public async Task UpdateAsync(TipoGastoFormDto dto)
        {
            var entity = await _repository.GetByIdAsync((Guid)dto.Id);
            if (entity == null) throw new KeyNotFoundException("Tipo de gasto no encontrado.");

            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
