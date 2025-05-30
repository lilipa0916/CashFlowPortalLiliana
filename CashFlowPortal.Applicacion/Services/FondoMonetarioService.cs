using AutoMapper;
using CashFlowPortal.Applicacion.DTOs.FondoMonetario;
using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using CashFlowPortal.Domain.Entities;
using FluentValidation;

namespace CashFlowPortal.Applicacion.Services
{
    public class FondoMonetarioService : IFondoMonetarioService
    {
        private readonly IFondoMonetarioRepository _repo;
        private readonly IMapper _mapper;
        private readonly IValidator<FondoMonetarioDto> _validator;

        public FondoMonetarioService(IFondoMonetarioRepository repo, IMapper mapper, IValidator<FondoMonetarioDto> validator)
        {
            _repo = repo;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<List<FondoMonetarioDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return _mapper.Map<List<FondoMonetarioDto>>(list);
        }
        public async Task<int> CreateAsync(FondoMonetarioDto dto)
        {
            await _validator.ValidateAndThrowAsync(dto);
            var entity = _mapper.Map<FondoMonetario>(dto);
            // FechaCreacion se asigna en repositorio si es default
            await _repo.AddAsync(entity);
            return entity.Id;
        }

        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);

        public async Task<FondoMonetarioDto?> GetByIdAsync(int id)
            => _mapper.Map<FondoMonetarioDto?>(await _repo.GetByIdAsync(id));

        public async Task UpdateAsync(int id, FondoMonetarioDto dto)
        {
            var entity = await _repo.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("FondoMonetario no encontrado");
            _mapper.Map(dto, entity);
            await _repo.UpdateAsync(entity);
        }
    }
}
