using AutoMapper;
using CashFlowPortal.Applicacion.DTOs.TipoGasto;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using CashFlowPortal.Applicacion.Interfaces.Repository;
using CashFlowPortal.Domain.Entities;

namespace CashFlowPortal.Applicacion.Services
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

        public async Task<IEnumerable<TipoGastoDto>> GetAllAsync()
        {
            var tipos = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TipoGastoDto>>(tipos);
        }

        public async Task<TipoGastoDto?> GetByIdAsync(Guid id)
        {
            var tipo = await _repository.GetByIdAsync(id);
            return _mapper.Map<TipoGastoDto?>(tipo);
        }
        public async Task<TipoGastoDto> CreateAsync(TipoGastoDto dto)
        {
            var entity = _mapper.Map<TipoGasto>(dto);

            // Suponiendo que el repositorio genera el código automáticamente
            entity.Codigo = await _repository.GenerarCodigoAsync();

            await _repository.AddAsync(entity);

            return _mapper.Map<TipoGastoDto>(entity);
        }

        public async Task CreateAsync(TipoGastoFormDto dto)
        {
            var tipo = _mapper.Map<TipoGasto>(dto);
            await _repository.AddAsync(tipo);
        }

        public async Task UpdateAsync(TipoGastoFormDto dto)
        {
            var existing = await _repository.GetByIdAsync((Guid)dto.Id);
            if (existing == null)
                throw new KeyNotFoundException("TipoGasto no encontrado.");

            // 2. Mappea solo las propiedades (no crees una nueva instancia)
            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);

    }
}
