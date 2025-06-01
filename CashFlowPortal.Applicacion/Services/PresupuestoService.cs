using AutoMapper;
using CashFlowPortal.Applicacion.DTOs.Presupuesto;
using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using CashFlowPortal.Domain.Entities;
using FluentValidation;

namespace CashFlowPortal.Applicacion.Services
{
    public class PresupuestoService : IPresupuestoService
    {
        private readonly IPresupuestoRepository _repo;
        private readonly IMapper _mapper;
        private readonly IValidator<PresupuestoDto> _validator;

        public PresupuestoService(
            IPresupuestoRepository repo,
            IMapper mapper,
            IValidator<PresupuestoDto> validator)
        {
            _repo = repo;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<List<PresupuestoDto>> GetByMesAsync(Guid usuarioId, DateTime mes)
        {
            var entities = await _repo.GetByMesAsync(usuarioId, mes);
            return _mapper.Map<List<PresupuestoDto>>(entities);
        }

        public async Task AddOrUpdateAsync(PresupuestoDto dto)
        {
           
            await _validator.ValidateAndThrowAsync(dto);
            var entity = _mapper.Map<Presupuesto>(dto);
            entity.Monto = dto.Monto;
            await _repo.AddOrUpdateAsync(entity);
        }
    }
}
