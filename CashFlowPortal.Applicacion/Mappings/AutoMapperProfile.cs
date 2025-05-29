using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Applicacion.DTOs.Presupuesto;
using CashFlowPortal.Applicacion.DTOs.TipoGasto;
using CashFlowPortal.Domain.Entities;
using AutoMapper;

namespace CashFlowPortal.Applicacion.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TipoGasto, TipoGastoDto>().ReverseMap();
            CreateMap<Usuario, LoginRequestDto>().ReverseMap();
            CreateMap<Presupuesto, PresupuestoDto>().ReverseMap();

        }
    }
}
