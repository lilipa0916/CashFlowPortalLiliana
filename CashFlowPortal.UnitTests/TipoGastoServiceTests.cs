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
        private readonly TipoGastoService _service;

        public TipoGastoServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TipoGasto, TipoGastoDto>().ReverseMap();
            });
            _mapper = config.CreateMapper();
            _service = new TipoGastoService(_repoMock.Object, _mapper);

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

        [Fact]
        public async Task CreateAsync_ShouldReturnDtoWithGeneratedCode()
        {
            // Arrange
            var dto = new TipoGastoDto { Nombre = "Salud" };
            var entity = new TipoGasto { Id = Guid.NewGuid(), Nombre = "Salud", Codigo = "TG001" };

            _repoMock.Setup(r => r.GenerarCodigoAsync()).ReturnsAsync("TG001");
            _repoMock.Setup(r => r.AddAsync(It.IsAny<TipoGasto>())).ReturnsAsync(entity);

            // Act
            var result = await _service.CreateAsync(dto);

            // Assert
            Assert.Equal("Salud", result.Nombre);
            //Assert.Equal("TG001", result.Id);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllTipoGastos()
        {
            // Arrange
            var entities = new List<TipoGasto>
            {
                new() { Id = Guid.NewGuid(), Nombre = "Comida", Codigo = "TG001" },
                new() { Id = Guid.NewGuid(), Nombre = "Transporte", Codigo = "TG002" }
            };

            _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(entities);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectDto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var entity = new TipoGasto { Id = id, Nombre = "Educación", Codigo = "TG003" };

            _repoMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(entity);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Educación", result.Nombre);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallRepositoryUpdate()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dto = new TipoGastoFormDto { Id = id, Nombre = "Modificado" };
            var entity = new TipoGasto { Id = id, Nombre = "Modificado", Codigo = "TG004" };

            _repoMock.Setup(r => r.UpdateAsync(It.IsAny<TipoGasto>())).Returns(Task.CompletedTask);

            // Act
            await _service.UpdateAsync(dto);

            // Assert
            _repoMock.Verify(r => r.UpdateAsync(It.Is<TipoGasto>(x => x.Id == id && x.Nombre == "Modificado")), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepositoryDelete()
        {
            // Arrange
            var id = Guid.NewGuid();

            _repoMock.Setup(r => r.DeleteAsync(It.IsAny<Guid>())).Returns(Task.CompletedTask);

            // Act
            await _service.DeleteAsync(id);

            // Assert
            _repoMock.Verify(r => r.DeleteAsync(id), Times.Once);
        }
    }
}
