using AutoMapper;
using CashFlowPortal.Applicacion.DTOs.FondoMonetario;
using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using CashFlowPortal.Domain.Entities;

namespace CashFlowPortal.Applicacion.Services
{
    public class FondoMonetarioService : IFondoMonetarioService
    {
        private readonly IFondoMonetarioRepository _repo;
        private readonly IMapper _mapper;

        public FondoMonetarioService(IFondoMonetarioRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<FondoMonetarioDto> CreateAsync(CreateFondoMonetarioDto dto)
        {
            var entity = _mapper.Map<FondoMonetario>(dto);
            var created = await _repo.AddAsync(entity);
            return _mapper.Map<FondoMonetarioDto>(created);
        }

        public async Task DeleteAsync(Guid id) => await _repo.DeleteAsync(id);

        public async Task<IEnumerable<FondoMonetarioDto>> GetAllAsync()
            => _mapper.Map<IEnumerable<FondoMonetarioDto>>(await _repo.GetAllAsync());

        public async Task<FondoMonetarioDto?> GetByIdAsync(Guid id)
            => _mapper.Map<FondoMonetarioDto?>(await _repo.GetByIdAsync(id));

        public async Task UpdateAsync(Guid id, CreateFondoMonetarioDto dto)
        {
            var entity = await _repo.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("FondoMonetario no encontrado");
            _mapper.Map(dto, entity);
            await _repo.UpdateAsync(entity);
        }
    }
}
