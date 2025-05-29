using CashFlowPortal.Applicacion.DTOs;
using CashFlowPortal.Applicacion.Validator;

namespace CashFlowPortal.UnitTests
{
    public class TipoGastoValidatorTests
    {
        [Fact]
        public void Nombre_Vacio_Deberia_Fallar()
        {
            var validator = new TipoGastoValidator();
            var result = validator.Validate(new TipoGastoDto { Nombre = "" });
            Assert.False(result.IsValid);
        }
    }
}