using AutoMapper;
using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Applicacion.DTOs.Deposito;
using CashFlowPortal.Applicacion.DTOs.FondoMonetario;
using CashFlowPortal.Applicacion.DTOs.Gasto;
using CashFlowPortal.Applicacion.DTOs.Presupuesto;
using CashFlowPortal.Applicacion.DTOs.TipoGasto;
using CashFlowPortal.Domain.Entities;

namespace CashFlowPortal.Applicacion.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TipoGasto, TipoGastoDto>().ReverseMap();
            CreateMap<Usuario, LoginRequestDto>().ReverseMap();
            CreateMap<Usuario, LoginResponseDto>().ReverseMap();
            CreateMap<TipoGastoFormDto, TipoGasto>().ReverseMap();
            CreateMap<FondoMonetario, FondoMonetarioDto>().ReverseMap();
            CreateMap<Presupuesto, PresupuestoDto>()
                .ForMember(d => d.Monto, opt => opt.MapFrom(src => src.Monto)) // Monto total, si lo manejas sumando detalles
                .ReverseMap();
            CreateMap<GastoDto, Gasto>().ReverseMap();
            CreateMap<GastoDetalleDto, GastoDetalle>().ReverseMap();
            CreateMap<DepositoDto, Deposito>().ReverseMap();
        }
    }
}
