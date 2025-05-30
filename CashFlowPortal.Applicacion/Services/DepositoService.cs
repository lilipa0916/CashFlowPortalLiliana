using AutoMapper;
using CashFlowPortal.Applicacion.DTOs.Deposito;
using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using CashFlowPortal.Domain.Entities;
using FluentValidation;

namespace CashFlowPortal.Applicacion.Services
{
    public class DepositoService : IDepositoService
    {
        private readonly IDepositoRepository _repo;
        private readonly IFondoMonetarioRepository _fondoRepo;
        private readonly IMapper _mapper;
        private readonly IValidator<DepositoDto> _validator;

        public DepositoService(
            IDepositoRepository repo,
            IFondoMonetarioRepository fondoRepo,
            IMapper mapper,
            IValidator<DepositoDto> validator)
        {
            _repo = repo;
            _fondoRepo = fondoRepo;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task CreateAsync(DepositoDto dto)
        {
            await _validator.ValidateAndThrowAsync(dto);
            var entity = _mapper.Map<Deposito>(dto);
            await _repo.AddAsync(entity);
        }

        public async Task<List<DepositoDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            var dtos = _mapper.Map<List<DepositoDto>>(list);
            // Rellenar FondoNombre
            foreach (var d in dtos)
            {
                var f = await _fondoRepo.GetByIdAsync(d.FondoMonetarioId);
                d.FondoNombre = f?.Nombre ?? "";
            }
            return dtos;
        }
    }
}
