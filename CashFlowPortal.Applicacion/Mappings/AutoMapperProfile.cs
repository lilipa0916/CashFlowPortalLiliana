using AutoMapper;
using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Applicacion.DTOs.FondoMonetario;
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
            CreateMap<Presupuesto, PresupuestoDto>().ReverseMap();
            CreateMap<CreateTipoGastoDto, TipoGasto>().ReverseMap();

            CreateMap<CreateFondoMonetarioDto, FondoMonetario>().ReverseMap();
            CreateMap<FondoMonetario, FondoMonetarioDto>().ReverseMap();
        }
    }
}
