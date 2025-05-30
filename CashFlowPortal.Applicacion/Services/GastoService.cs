using AutoMapper;
using CashFlowPortal.Applicacion.DTOs.Gasto;
using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using CashFlowPortal.Applicacion.Interfaces.Repository;
using CashFlowPortal.Applicacion.Interfaces.Services;
using CashFlowPortal.Domain.Entities;
using FluentValidation;

namespace CashFlowPortal.Applicacion.Services
{
    public class GastoService : IGastoService
    {
        private readonly IGastoRepository _repo;
        private readonly IPresupuestoRepository _presRepo;
        private readonly ITipoGastoRepository _tipoRepo;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;
        private readonly IValidator<GastoDto> _validator;

        public GastoService(
            IGastoRepository repo,
            IPresupuestoRepository presRepo,
            ITipoGastoRepository tipoRepo,
            ICurrentUserService currentUser,
            IMapper mapper,
            IValidator<GastoDto> validator)
        {
            _repo = repo;
            _presRepo = presRepo;
            _tipoRepo = tipoRepo;
            _currentUser = currentUser;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> CreateAsync(GastoDto dto)
        {
            // 1) Valida DTO
            await _validator.ValidateAndThrowAsync(dto);

            // 2) Mapea a entidad
            var entidad = _mapper.Map<Gasto>(dto);

            // 3) Obtiene el usuario y el mes
            var usuarioId = await _currentUser.GetUserIdAsync();
            var mes = new DateTime(dto.Fecha.Year, dto.Fecha.Month, 1);

            // 4) Chequeo de sobregiro
            var errores = new List<string>();
            foreach (var det in dto.Detalles)
            {
                var presus = await _presRepo.GetByMesAsync(usuarioId, mes);
                var pres = presus.FirstOrDefault(p => p.TipoGastoId == det.TipoGastoId);
                var gastado = await _repo.SumByTipoAndMesAsync(det.TipoGastoId, mes);

                if (pres != null && gastado + det.Monto > pres.Monto)
                {
                    var tipo = await _tipoRepo.GetByIdAsync(det.TipoGastoId);
                    var nombre = tipo?.Nombre ?? det.TipoGastoId.ToString();
                    errores.Add($"{nombre}: presupuesto {pres.Monto:C}, gastado {gastado + det.Monto:C}");
                }
            }
            if (errores.Any())
                throw new ValidationException("Sobregiro en: " + string.Join("; ", errores));

            // 5) Inserta con transacción
            return await _repo.AddWithDetalleAsync(entidad);
        }
    }
}
