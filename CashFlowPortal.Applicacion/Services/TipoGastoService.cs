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

        public async Task CreateAsync(CreateTipoGastoDto dto)
        {
            var tipo = _mapper.Map<TipoGasto>(dto);
            await _repository.AddAsync(tipo);
        }

        public async Task UpdateAsync(UpdateTipoGastoDto dto)
        {
            var tipo = _mapper.Map<TipoGasto>(dto);
            await _repository.UpdateAsync(tipo);
        }

        public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);

    }
}
