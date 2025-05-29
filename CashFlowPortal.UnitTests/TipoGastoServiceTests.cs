using AutoMapper;
using CashFlowPortal.Applicacion.DTOs.TipoGasto;
using CashFlowPortal.Applicacion.Interfaces.Repository;
using CashFlowPortal.Applicacion.Services;
using CashFlowPortal.Domain.Entities;
using Moq;

namespace CashFlowPortal.UnitTests
{
    public class TipoGastoServiceTests
    {
        private readonly Mock<ITipoGastoRepository> _repoMock = new();
        private readonly IMapper _mapper;

        public TipoGastoServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TipoGasto, TipoGastoDto>().ReverseMap();
            });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllTipoGastoDtos()
        {
            _repoMock.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<TipoGasto>
        {
            new() { Id = Guid.NewGuid(), Nombre = "Comida" },
            new() { Id = Guid.NewGuid(), Nombre = "Transporte" }
        });

            var service = new TipoGastoService(_repoMock.Object, _mapper);
            var result = await service.GetAllAsync();

            Assert.Equal(2, result.Count());
        }
    }
}
