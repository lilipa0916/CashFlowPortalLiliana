using AutoMapper;
using CashFlowPortal.Applicacion.DTOs;
using CashFlowPortal.Domain.Entities;

namespace CashFlowPortal.Applicacion.Mappings
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
